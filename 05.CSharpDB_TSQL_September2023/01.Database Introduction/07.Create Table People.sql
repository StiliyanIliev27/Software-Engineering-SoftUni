CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL, 
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
)
INSERT INTO [People] ([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
('Gosho', 1.77, 75.2, 'm', '1995-05-25'),
('Petko', 1.69, 65.8, 'm', '1999-10-22'),
('Stanka', 1.85, 73.8, 'f', '1997-05-25'),
('Maria', 1.62, 50.5, 'f', '1996-05-25'),
('Stiliyan', 1.79, 69.2, 'm', '2005-05-25')