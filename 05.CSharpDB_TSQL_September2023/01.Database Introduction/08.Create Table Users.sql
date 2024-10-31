CREATE TABLE [Users](
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	[LastLoginTime] DATETIME2,
	[IsDeleted] VARCHAR(5)
)

INSERT INTO [Users] ([Username], [Password], [IsDeleted])
	VALUES
('Gosho123', '12345678', 'true'),
('PetkoBg', '123454321', 'false'),
('Stanka6matkata', 'stankathebest', 'false'),
('Mimito76', '12345mariikabg123', 'true'),
('Stiliyan7', '122333444455555', 'true')

SELECT * FROM [Users]