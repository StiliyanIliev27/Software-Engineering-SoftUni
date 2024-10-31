--Database Basics MS SQL Regular Exam – 15 Oct 2023

--Tourist Agency

--Section 1. DDL 

--01.Database design

CREATE DATABASE TouristAgency

USE TouristAgency

CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY
	,[Type] VARCHAR(40) NOT NULL
	,Price DECIMAL(18, 2) NOT NULL 
	,BedCount INT CHECK(BedCount BETWEEN 1 AND 10) NOT NULL
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,DestinationId INT FOREIGN KEY REFERENCES Destinations(Id) NOT NULL
)

CREATE TABLE Tourists(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(80) NOT NULL
	,PhoneNumber VARCHAR(20) NOT NULL
	,Email VARCHAR(80)
	,CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Bookings(
	Id INT PRIMARY KEY IDENTITY
	,ArrivalDate DATETIME2 NOT NULL
	,DepartureDate DATETIME2 NOT NULL
	,AdultsCount INT CHECK(AdultsCount BETWEEN 1 AND 10) NOT NULL
	,ChildrenCount INT CHECK(ChildrenCount BETWEEN 0 AND 9) NOT NULL
	,TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL
	,HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
	,RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL
)

CREATE TABLE HotelsRooms(
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
	,RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL
	,PRIMARY KEY(HotelId, RoomId)
)

--Section 2. DML 

--The DataSet has inserted into tables succesfully!

--02.Insert

INSERT INTO Tourists([Name], PhoneNumber, Email, CountryId)
	VALUES
				('John Rivers',	'653-551-1555',	'john.rivers@example.com', 6)
				,('Adeline Aglaé',	'122-654-8726',	'adeline.aglae@example.com',	2)
				,('Sergio Ramirez',	'233-465-2876',	's.ramirez@example.com',	3)
				,('Johan Müller',	'322-876-9826',	'j.muller@example.com',	7)
				,('Eden Smith',	'551-874-2234',	'eden.smith@example.com',	6)

INSERT INTO Bookings(ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
	VALUES
				('2024-03-01',	'2024-03-11',	1,	0,	21,	3,	5)
				,('2023-12-28',	'2024-01-06',	2,	1,	22,	13,	3)
				,('2023-11-15',	'2023-11-20',	1,	2,	23,	19,	7)
				,('2023-12-05',	'2023-12-09',	4,	0,	24,	6,	4)
				,('2024-05-01',	'2024-05-07',	6,	0,	25,	14,	6)

--03.Update

UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE MONTH(ArrivalDate) = 12

UPDATE Tourists
SET Email = NULL
WHERE [Name] LIKE '%MA%'

--04.Delete

DELETE FROM Bookings
WHERE TouristId IN(SELECT Id FROM Tourists
					WHERE SUBSTRING([Name], CHARINDEX(' ', [Name]) + 1
					, LEN([Name])) LIKE 'Smith')

DELETE FROM Tourists
WHERE Id IN(SELECT Id FROM Tourists
					WHERE SUBSTRING([Name], CHARINDEX(' ', [Name]) + 1
					, LEN([Name])) LIKE 'Smith')

--Section 3. Querying 

--05.Bookings by Price of Room and Arrival Date

SELECT 
	FORMAT(ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate
	,AdultsCount
	,ChildrenCount
FROM Bookings b
	JOIN Rooms r ON r.Id = b.RoomId
ORDER BY Price DESC, ArrivalDate

--06.Hotels by Count of Bookings

SELECT * FROM
(SELECT
	h.Id
	,h.[Name]
FROM Bookings b
	JOIN Hotels h ON h.Id = b.HotelId
	JOIN HotelsRooms hr ON hr.HotelId = h.Id
	JOIN Rooms r ON r.Id = hr.RoomId
WHERE r.[Type] = 'VIP Apartment') AS CoreQuery
GROUP BY Id, [Name]
ORDER BY COUNT(Id) DESC

--07.Tourists without Bookings

SELECT 
	Id
	,[Name]
	,PhoneNumber
FROM Tourists
WHERE Id NOT IN(SELECT TouristId FROM Bookings)
ORDER BY [Name]

--8.First 10 Bookings

SELECT TOP(10)
	h.[Name] AS HotelName
	,d.[Name] AS DestinationName
	,c.[Name] AS CountryName
FROM Bookings b
	JOIN Hotels h ON h.Id = b.HotelId
	JOIN Destinations d ON d.Id = h.DestinationId
	JOIN Countries c ON c.Id = d.CountryId
WHERE ArrivalDate < '2023-12-31' AND h.Id % 2 = 1
ORDER BY CountryName, ArrivalDate

--9.Tourists booked in Hotels

SELECT
	h.[Name] AS HotelName
	,r.Price AS RoomPrice
FROM Tourists t
	JOIN Bookings b ON b.TouristId = t.Id
	JOIN Hotels h ON h.Id = b.HotelId
	JOIN Rooms r ON r.Id = b.RoomId
WHERE t.[Name] NOT LIKE '%EZ'
ORDER BY RoomPrice DESC

--10.Hotels Revenue

SELECT
	h.[Name] AS HotelName
	,SUM(DATEDIFF(DAY, ArrivalDate, DepartureDate) * r.Price) AS HotelRevenue
FROM Bookings b
	JOIN Hotels h ON h.Id = b.HotelId
	JOIN Rooms r ON r.Id = b.RoomId
GROUP BY h.[Name]
ORDER BY HotelRevenue DESC

--Section 4. Programmability 

--11.Rooms with Tourists

CREATE FUNCTION udf_RoomsWithTourists(@Name VARCHAR(40))
RETURNS INT
AS
BEGIN	
	DECLARE @count INT = 
	(
		SELECT
			SUM(b.ChildrenCount + b.AdultsCount) 
		FROM Tourists t
			JOIN Bookings b ON b.TouristId = t.Id
			JOIN Rooms r ON r.Id = b.RoomId
		WHERE r.[Type] = @Name
	)

	RETURN @count
END

SELECT dbo.udf_RoomsWithTourists('Double Room')
--In this case we call the function and we expect to receive 17 as a result.

--12.Search for Tourists from a Specific Country

CREATE PROCEDURE usp_SearchByCountry(@Country NVARCHAR(50))
AS
BEGIN
	SELECT
		t.[Name]
		,PhoneNumber
		,Email
		,COUNT(b.Id) AS CountOfBookings
	FROM Tourists t
		JOIN Bookings b ON b.TouristId = t.Id
		JOIN Countries c ON c.Id = t.CountryId
	WHERE c.[Name] = @Country
	GROUP BY t.[Name], PhoneNumber, Email
END

EXEC usp_SearchByCountry 'Greece'
--In this particular situation, we are given the country Greece.
--So we are looking for the correct table we want to receive as a result.