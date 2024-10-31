--01.Database design

CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY
	,StreetName NVARCHAR(20) NOT NULL
	,StreetNumber INT
	,PostCode INT NOT NULL
	,City VARCHAR(25) NOT NULL
	,CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Vendors(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(25) NOT NULL
	,NumberVAT NVARCHAR(15) NOT NULL
	,AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(25) NOT NULL
	,NumberVAT NVARCHAR(15) NOT NULL
	,AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Products(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(35) NOT NULL
	,Price DECIMAL(18, 2) NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,VendorId INT FOREIGN KEY REFERENCES Vendors(Id) NOT NULL
)

CREATE TABLE Invoices(
	Id INT PRIMARY KEY IDENTITY
	,Number INT UNIQUE NOT NULL
	,IssueDate DATETIME2 NOT NULL
	,DueDate DATETIME2 NOT NULL
	,Amount DECIMAL(18, 2) NOT NULL
	,Currency VARCHAR(5) NOT NULL
	,ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
)

CREATE TABLE ProductsClients(
	ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL
	,ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
	PRIMARY KEY(ProductId, ClientId)
)

--02.Insert

INSERT INTO Products([Name], Price, CategoryId, VendorId)
	VALUES
				('SCANIA Oil Filter XD01',	78.69,	1,	1)
				,('MAN Air Filter XD01',	97.38,	1,	5)
				,('DAF Light Bulb 05FG87',	55.00,	2,	13)
				,('ADR Shoes 47-47.5',	49.85,	3,	5)
				,('Anti-slip pads S',	5.87,	5,	7)

INSERT INTO Invoices(Number, IssueDate, DueDate, Amount, Currency, ClientId)
	VALUES
				(1219992181,	'2023-03-01',	'2023-04-30',	180.96,	'BGN',	3)
				,(1729252340,	'2022-11-06',	'2023-01-04',	158.18,	'EUR',	13)
				,(1950101013,	'2023-02-17',	'2023-04-18',	615.15,	'USD',	19)

--03.Update

UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE YEAR(IssueDate) = 2022 AND MONTH(IssueDate) = 11

UPDATE Clients
SET AddressId = 3
WHERE [Name] LIKE '%CO%'

--04.Delete

DELETE FROM ProductsClients
WHERE ClientId = 11

DELETE FROM Invoices
WHERE ClientId = 11

DELETE FROM Clients
WHERE NumberVAT LIKE 'IT%'

--05.Invoices by Amount and Date

SELECT 
	Number
	,Currency
FROM Invoices
ORDER BY Amount DESC, DueDate

--06.Products by Category

SELECT
	p.Id
	,p.[Name]
	,Price
	,c.[Name] AS CategoryName
FROM Products p
	JOIN Categories c ON c.Id = p.CategoryId
WHERE c.[Name] IN('ADR', 'Others')
ORDER BY Price DESC

--07.Clients without Products

SELECT
	c.Id
	,c.[Name]
	,CONCAT(StreetName, ' ', StreetNumber, ',', ' ', City, ',', ' ', PostCode, ',', ' ', co.[Name])
FROM Clients c
	JOIN Addresses a ON a.Id = c.AddressId
	JOIN Countries co ON co.Id = a.CountryId
WHERE c.Id NOT IN(SELECT ClientId FROM ProductsClients)
ORDER BY c.[Name]

--08.First 7 Invoices

SELECT TOP(7)
	Number
	,Amount
	,c.[Name]
FROM Invoices i
	JOIN Clients c ON c.Id = i.ClientId
WHERE IssueDate < '2023-01-01' AND Currency = 'EUR'
			OR Amount > 500.00 AND c.NumberVAT LIKE 'DE%'
ORDER BY Number, Amount DESC

--09.Clients with VAT

SELECT * FROM
(SELECT
	c.[Name] AS Client
	,MAX(p.Price) AS Price
	,NumberVAT AS [VAT Number]
FROM Clients c
	JOIN ProductsClients pc ON pc.ClientId = c.Id
	JOIN Products p ON p.Id = pc.ProductId
GROUP BY c.[Name], NumberVAT
HAVING c.[Name] NOT LIKE '%KG'
) AS CoreQuery
ORDER BY Price DESC

--10.Clients by Price

SELECT * FROM
(SELECT
	c.[Name] AS Client
	,FLOOR(AVG(p.Price)) AS [Average Price]
FROM Clients c
	JOIN ProductsClients pc ON pc.ClientId = c.Id
	JOIN Products p ON p.Id = pc.ProductId
	JOIN Vendors v ON v.Id = p.VendorId
WHERE v.NumberVAT LIKE '%FR%'
GROUP BY c.[Name]) AS CoreQuery
ORDER BY [Average Price], Client DESC

--11.Product with Clients

CREATE FUNCTION udf_ProductWithClients(@Name NVARCHAR(255))
RETURNS INT
AS
BEGIN
	DECLARE @count INT = (SELECT
		COUNT(*)
	FROM Clients c
		JOIN ProductsClients pc ON pc.ClientId = c.Id
		JOIN Products p ON p.Id = pc.ProductId
	WHERE p.[Name] = @Name)

	RETURN @count
END

--12.Search for Vendors from a Specific Country

CREATE PROCEDURE usp_SearchByCountry(@Country VARCHAR(10))
AS
BEGIN
	SELECT 
		v.[Name] AS Vendor
		,NumberVAT AS VAT
		,CONCAT_WS(' ', a.StreetName, a.StreetNumber) AS [Street Info]
		,CONCAT_WS(' ', a.City, a.PostCode) AS [City Info]
	FROM Vendors v
		JOIN Addresses a ON a.Id = v.AddressId
		JOIN Countries c ON c.Id = a.CountryId
	WHERE c.[Name] = @Country
	ORDER BY v.[Name], City 
END