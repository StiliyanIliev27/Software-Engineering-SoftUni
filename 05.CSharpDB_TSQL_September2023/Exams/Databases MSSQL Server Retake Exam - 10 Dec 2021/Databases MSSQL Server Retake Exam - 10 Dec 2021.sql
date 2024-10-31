--Section 1. DDL 

--01.Database design

CREATE DATABASE Airport

USE Airport

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY
	,FullName VARCHAR(100) UNIQUE NOT NULL
	,Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots(
	Id INT PRIMARY KEY IDENTITY
	,FirstName VARCHAR(30) UNIQUE NOT NULL
	,LastName VARCHAR(30) UNIQUE NOT NULL
	,Age TINYINT CHECK(Age BETWEEN 21 AND 62) NOT NULL
	,Rating FLOAT CHECK(Rating BETWEEN 0.0 AND 10.0)
)

CREATE TABLE AircraftTypes(
	Id INT PRIMARY KEY IDENTITY
	,TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft(
	Id INT PRIMARY KEY IDENTITY
	,Manufacturer VARCHAR(25) NOT NULL
	,Model VARCHAR(30) NOT NULL
	,[Year] INT NOT NULL
	,FlightHours INT
	,Condition CHAR(1) NOT NULL
	,TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
)

CREATE TABLE PilotsAircraft(
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL
	,PilotId INT FOREIGN KEY REFERENCES Pilots(Id) NOT NULL
	PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports(
	Id INT PRIMARY KEY IDENTITY
	,AirportName VARCHAR(70) UNIQUE NOT NULL
	,Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations(
	Id INT PRIMARY KEY IDENTITY
	,AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL
	,[Start] DATETIME NOT NULL
	,AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL
	,PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
	,TicketPrice DECIMAL(18, 2) DEFAULT 15 NOT NULL
)

--Section 2. DML 

--02.Insert

DECLARE @i INT = 5

WHILE(@i < 16)
	BEGIN
		INSERT INTO Passengers([FullName], Email)
			VALUES ((SELECT
						CONCAT_WS(' ', FirstName, LastName)
					FROM Pilots
					WHERE Id = @i
					),	(SELECT
						CONCAT(FirstName, LastName, '@gmail.com')
					FROM Pilots
					WHERE Id = @i))	
			SET @i += 1
	END

--03.Update

UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN('C', 'B') AND (FlightHours <= 100 
		OR FlightHours IS NULL) AND [YEAR] >= 2013

--04.Delete

DELETE FROM FlightDestinations
WHERE PassengerId IN
	(
		SELECT 
			Id
		FROM Passengers
		WHERE LEN(FullName) <= 10
	)

DELETE FROM Passengers
WHERE Id IN
	(
		SELECT 
			Id
	FROM Passengers
	WHERE LEN(FullName) <= 10
	)


--Section 3. Querying 

--05.Aircraft

SELECT
	Manufacturer
	,Model
	,FlightHours
	,Condition
FROM Aircraft
ORDER BY FlightHours DESC

--06.Pilots and Aircraft

SELECT
	FirstName
	,LastName
	,Manufacturer
	,Model
	,FlightHours
FROM Pilots p
	JOIN PilotsAircraft pa ON pa.PilotId = p.Id
	JOIN Aircraft a ON a.Id = pa.AircraftId
WHERE FlightHours < 304
ORDER BY FlightHours DESC, FirstName

--07.Top 20 Flight Destinations

SELECT TOP(20)
	fd.Id AS DestinationId
	,[Start]
	,p.FullName
	,AirportName
	,TicketPrice
FROM FlightDestinations fd
	JOIN Passengers p ON p.Id = fd.PassengerId
	JOIN Airports a ON a.Id = fd.AirportId
WHERE DAY([Start]) % 2 = 0
ORDER BY TicketPrice DESC, AirportName

--08.Number of Flights for Each Aircraft

SELECT * FROM
(SELECT
	a.Id
	,Manufacturer
	,FlightHours
	,COUNT(fd.Id) AS FlightDestinationsCount
	,ROUND(AVG(TicketPrice), 2) AS AvgPrice
FROM Aircraft a
	JOIN FlightDestinations fd ON fd.AircraftId = a.Id
GROUP BY a.Id, Manufacturer, FlightHours) AS CoreQuery
GROUP BY Id, Manufacturer, FlightHours, FlightDestinationsCount, AvgPrice
HAVING FlightDestinationsCount >= 2 
ORDER BY FlightDestinationsCount DESC, Id

--09.Regular Passengers

SELECT * FROM
(SELECT
	FullName
	,COUNT(*) AS CountOfAircraft
	,SUM(TicketPrice) AS TotalPayed
FROM Passengers p
	JOIN FlightDestinations fd ON fd.PassengerId = p.Id
	JOIN Aircraft a ON a.Id = fd.AircraftId
GROUP BY FullName
HAVING FullName LIKE '_a%' ) AS CoreQuery
WHERE CountOfAircraft > 1
ORDER BY FullName

--10.Full Info for Flight Destinations

SELECT
	AirportName
	,[Start] AS DayTime
	,TicketPrice
	,FullName
	,Manufacturer
	,Model
FROM FlightDestinations fd
	JOIN Airports a ON a.Id = fd.AirportId
	JOIN Passengers p ON p.Id = fd.PassengerId
	JOIN Aircraft ac ON ac.Id = fd.AircraftId
WHERE DATEPART(HOUR, [Start]) BETWEEN 6 AND 20
		AND TicketPrice > 2500
ORDER BY Model

--Section 4. Programmability 

--11.Find all Destinations by Email Address

CREATE FUNCTION udf_FlightDestinationsByEmail(@Email VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @count INT =
	(	
		SELECT
			COUNT(*)
		FROM Passengers p
			JOIN FlightDestinations fd ON fd.PassengerId = p.Id
		WHERE Email = @Email
	)

	RETURN @count
END

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
--In this case we call the function and we expect to receive 1 as a result.

--12.Full Info for Airports

CREATE PROCEDURE usp_SearchByAirportName(@AirportName VARCHAR(70))
AS
BEGIN
	SELECT 
		AirportName
		,FullName
		,Manufacturer
		,CASE
			WHEN TicketPrice 
		,Condition
	FROM Airports a
		JOIN FlightDestinations fd ON fd.AirportId = a.Id
		JOIN Passengers p ON p.Id = fd.PassengerId
		JOIN Aircraft ac ON ac.Id = fd.AircraftId
		JOIN AircraftTypes [at] ON [at].Id = ac.TypeId
	WHERE AirportName = @AirportName
END