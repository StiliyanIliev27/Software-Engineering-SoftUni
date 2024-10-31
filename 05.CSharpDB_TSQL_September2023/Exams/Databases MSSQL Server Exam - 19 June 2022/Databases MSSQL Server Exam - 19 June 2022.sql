--Section 1. DDL 

--01.Database design

CREATE DATABASE Zoo

USE Zoo

CREATE TABLE Owners(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,PhoneNumber VARCHAR(15) NOT NULL
	,[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes(
	Id INT PRIMARY KEY IDENTITY
	,AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
	Id INT PRIMARY KEY IDENTITY
	,AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE Animals(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(30) NOT NULL
	,BirthDate DATE NOT NULL
	,OwnerId INT FOREIGN KEY REFERENCES Owners(Id)
	,AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE AnimalsCages(
	CageId INT FOREIGN KEY REFERENCES Cages(Id)
	,AnimalId INT FOREIGN KEY REFERENCES Animals(Id)
	PRIMARY KEY(CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
	Id INT PRIMARY KEY IDENTITY
	,DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,PhoneNumber VARCHAR(15) NOT NULL
	,[Address] VARCHAR(50)
	,AnimalId INT FOREIGN KEY REFERENCES Animals(Id)
	,DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
)

--Section 2. DML

--02.Insert

INSERT INTO Volunteers([Name], PhoneNumber, [Address], AnimalId, DepartmentId)
	VALUES 
				('Anita Kostova',	'0896365412',	'Sofia, 5 Rosa str.',	15,	1)
				,('Dimitur Stoev',	'0877564223',	null,	42,	4)
				,('Kalina Evtimova',	'0896321112',	'Silistra, 21 Breza str.',	9,	7)
				,('Stoyan Tomov',	'0898564100', 'Montana, 1 Bor str.',	18,	8)
				,('Boryana Mileva',	'0888112233',	null,	31,	5)

INSERT INTO Animals([Name], BirthDate, OwnerId, AnimalTypeId)
	VALUES
				('Giraffe',	'2018-09-21',	21,	1)
				,('Harpy Eagle',	'2015-04-17',	15,	3)
				,('Hamadryas Baboon',	'2017-11-02',	null,	1)
				,('Tuatara',	'2021-06-30',	2,	4)

--03.Update

UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL

--04.Delete

DELETE FROM Volunteers
WHERE DepartmentId = 2

DELETE FROM VolunteersDepartments
WHERE Id = 2

--Section 3. Querying 

--05.Volunteers

SELECT
	[Name]
	,PhoneNumber
	,[Address]
	,AnimalId
	,DepartmentId
FROM Volunteers
ORDER BY [Name], DepartmentId 

--06.Animals data

SELECT
	[Name]
	,[at].AnimalType
	,FORMAT(BirthDate, 'dd.MM.yyyy') AS BirthDate
FROM Animals a
	JOIN AnimalTypes [at] ON [at].Id = a.AnimalTypeId
ORDER BY [Name]

--07.Owners and Their Animals

SELECT TOP(5)
	o.[Name] AS [Owner]
	,COUNT(*) AS CountOfAnimals
FROM Owners o
	JOIN Animals a ON a.OwnerId = o.Id
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC, [Owner]

--08.Owners, Animals and Cages

SELECT 
	CONCAT_WS('-', o.[Name], a.[Name]) AS OwnersAnimals
	,PhoneNumber
	,CageId
FROM Owners o
	JOIN Animals a ON a.OwnerId = o.Id
	JOIN AnimalsCages ac ON ac.AnimalId = a.Id
	JOIN AnimalTypes [at] ON [at].Id = a.AnimalTypeId
WHERE AnimalType = 'Mammals'
ORDER BY o.[Name], a.[Name] DESC

--9.Volunteers in Sofia

SELECT
	[Name]
	,PhoneNumber
	,SUBSTRING([Address], CHARINDEX(',', [Address]) + 1, LEN([Address])) AS [Address]
FROM Volunteers
	WHERE DepartmentId = 2 AND SUBSTRING([Address], 1, 5) = 'Sofia' 
				OR SUBSTRING([Address], 2, 5) = 'Sofia'
ORDER BY [Name]

--10.Animals for Adoption

SELECT
	[Name]
	,YEAR(BirthDate) AS BirtYear
	,[at].AnimalType
FROM Animals a
	JOIN AnimalTypes [at] ON [at].Id = a.AnimalTypeId
WHERE OwnerId IS NULL AND BirthDate > '2018-01-01' 
		 AND AnimalType NOT LIKE 'Birds'
ORDER BY [Name]

--Section 4. Programmability 

--11.All Volunteers in a Department

CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @countOfVolunteers INT = 
	(
		SELECT 
			COUNT(*)
		FROM Volunteers v
			JOIN VolunteersDepartments vd ON vd.Id = v.DepartmentId
		WHERE vd.DepartmentName = @VolunteersDepartment
	)

	RETURN @countOfVolunteers
END

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')
--The procedure should work properly if with this input param procedure returns 6 as a result.

--12.Animals with Owner or Not

CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	DECLARE @animalId INT = (SELECT 
		Id
	FROM Animals
	WHERE [Name] = @AnimalName)

	SELECT 
		a.[Name]
		,CASE
			WHEN a.OwnerId IS NULL THEN 'For adoption'
			ELSE o.[Name]
		END AS OwnersName
	FROM Owners o
		 RIGHT JOIN Animals a ON a.OwnerId = o.Id
	WHERE a.Id = @animalId
END


EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
--In this case if the procedure works correctly we should get Hippo with 'OwnersName' - For adoption

EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'
--Second example with input like this should return a table with Brown bear and its owner Gergana Mancheva 