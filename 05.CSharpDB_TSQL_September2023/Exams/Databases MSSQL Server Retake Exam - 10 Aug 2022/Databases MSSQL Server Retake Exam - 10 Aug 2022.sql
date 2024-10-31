--Section 1. DDL 

--01.Table design

CREATE DATABASE NationalTouristSitesOfBulgaria

USE NationalTouristSitesOfBulgaria

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Locations(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,Municipality VARCHAR(50)
	,Province VARCHAR(50)
)

CREATE TABLE Sites(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(100) NOT NULL
	,LocationId INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
    ,Establishment VARCHAR(15)
)

CREATE TABLE Tourists(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,Age INT CHECK(Age >= 0 AND Age <= 120) NOT NULL
	,PhoneNumber VARCHAR(20) NOT NULL
	,Nationality VARCHAR(30) NOT NULL
	,Reward VARCHAR(20)
)

CREATE TABLE SitesTourists(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL
	,SiteId INT FOREIGN KEY REFERENCES Sites(Id) NOT NULL
	,PRIMARY KEY(TouristId, SiteId)
)

CREATE TABLE BonusPrizes(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL
	,BonusPrizeId INT FOREIGN KEY REFERENCES BonusPrizes(Id) NOT NULL
	,PRIMARY KEY(TouristId, BonusPrizeId)
)

--Section 2. DML 

--02.Insert

INSERT INTO Tourists([Name], Age, PhoneNumber, Nationality, Reward)
	VALUES
				('Borislava Kazakova', 52,	'+359896354244',	'Bulgaria',	NULL)
				,('Peter Bosh',	48,	'+447911844141',	'UK',	NULL)
				,('Martin Smith',	29,	'+353863818592',	'Ireland',	'Bronze badge')
				,('Svilen Dobrev',	49,	'+359986584786',	'Bulgaria',	'Silver badge')
				,('Kremena Popova',	38,	'+359893298604',	'Bulgaria',	NULL)
				
INSERT INTO Sites([Name], LocationId, CategoryId, Establishment)
	VALUES
				('Ustra fortress',	90,	7,	'X')
				,('Karlanovo Pyramids',	65,	7,	NULL)
				,('The Tomb of Tsar Sevt',	63,	8,	'V BC')
				,('Sinite Kamani Natural Park',	17,	1,	NULL)
				,('St. Petka of Bulgaria – Rupite',	92,	6,	'1994')


--03.Update

UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL

--04.Delete

DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId = 5

UPDATE Tourists
SET Reward = NULL
WHERE Id IN(SELECT
	TouristId
FROM TouristsBonusPrizes
WHERE BonusPrizeId = 5)

DELETE FROM BonusPrizes
WHERE Id = 5

--Section 3.Querying 

--05.Tourists

SELECT
	[Name]
	,Age
	,PhoneNumber
	,Nationality
FROM Tourists
ORDER BY Nationality, Age DESC, [Name]

--06.Sites with Their Location and Category

SELECT
	s.[Name] AS Site
	,l.[Name]
	,Establishment
	,c.[Name] AS Category
FROM Sites s
	JOIN Locations l ON l.Id = s.LocationId
	JOIN Categories c ON c.Id = s.CategoryId
ORDER BY c.[Name] DESC, l.[Name], s.[Name]

--07.Count of Sites in Sofia Province

SELECT * FROM
(SELECT
	Province
	,Municipality
	,l.[Name] AS [Location]
	,COUNT(*) AS CountOfSites
FROM Sites s
	JOIN Locations l ON l.Id = s.LocationId
WHERE Province = 'Sofia'
GROUP BY Province, Municipality, l.[Name]) AS CoreQuery
ORDER BY CountOfSites DESC, [Location]

--08.Tourist Sites established BC

SELECT
	s.[Name] AS [Site]
	,l.[Name] AS [Location]
	,Municipality
	,Province
	,Establishment
FROM Sites s
	 JOIN Locations l ON l.Id = s.LocationId
WHERE l.[Name] NOT LIKE '[BMD]%'
		AND Establishment LIKE '%BC'
ORDER BY s.[Name]

--9.Tourists with their Bonus Prizes

SELECT
	t.[Name]
	,Age
	,PhoneNumber
	,Nationality
	,CASE
		WHEN bp.[Name] IS NULL THEN '(no bonus prize)'
		ELSE bp.[Name]
	END AS [Reward]
FROM Tourists t
	LEFT JOIN TouristsBonusPrizes tbp ON tbp.TouristId = t.Id
	LEFT JOIN BonusPrizes bp ON bp.Id = tbp.BonusPrizeId
ORDER BY [Name]

--10.Tourists visiting History and Archaeology sites

SELECT * FROM
(SELECT
	SUBSTRING(t.[Name], CHARINDEX(' ', t.[Name]) + 1, LEN(t.[Name])) AS LastName
	,Nationality
	,Age
	,PhoneNumber
FROM Tourists t
	JOIN SitesTourists st ON st.TouristId = t.Id
	JOIN Sites s ON s.Id = st.SiteId
	JOIN Categories c ON c.Id = s.CategoryId
WHERE c.[Name] = 'History and archaeology') AS CoreQuery
GROUP BY LastName, Nationality, Age, PhoneNumber
ORDER BY LastName


--11.Tourists Count on a Tourist Site

CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @countOfTourists INT = 
	(
		SELECT	
			COUNT(*) 
		FROM Tourists t
			JOIN SitesTourists st ON st.TouristId = t.Id
			JOIN Sites s ON s.Id = st.SiteId
		WHERE s.[Name] = @Site
	)

	RETURN @countOfTourists		
END

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')
--In this case the function should return 6 as a result.

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')
--And another example of the functionality which proves that the function is working properly, it should return 8 this time.

--12.Annual Reward Lottery

CREATE PROCEDURE usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
	--First step is to get the count of the tourist's sites by declaring à variable.
	DECLARE @countOfSites INT = 
	(
		SELECT 
			COUNT(*)
		FROM Sites s
			JOIN SitesTourists st ON st.SiteId = s.Id
			JOIN Tourists t ON t.Id = st.TouristId
		WHERE t.[Name] = @TouristName
	)

	--Second we need to update the data in our DataBase.
	UPDATE Tourists
	SET Reward =
		CASE 
			 WHEN @countOfSites >= 100 THEN 'Gold badge'
			 WHEN @countOfSites >= 50 THEN 'Silver badge'
			 WHEN @countOfSites >= 25 THEN 'Bronze badge'
	    END 
	WHERE [Name] = @TouristName

	--Finally the exercise expects from us to extract the name of the tourist and the reward he has.
	--So we use SELECT and the task is done!
	SELECT 
		[Name]
		,Reward
	FROM Tourists
	WHERE [Name] = @TouristName
END

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'
--Just as an example, when we execute the procedure with the given name 'Gerhild Lutgard', we should expect to see Gerhild Lutgard, who has a Gold badge reward.