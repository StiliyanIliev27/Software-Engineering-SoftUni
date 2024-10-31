CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY
	,DirectorName NVARCHAR(50) NOT NULL
	,Notes VARCHAR(255)
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY
	,GenreName NVARCHAR(50) NOT NULL
	,Notes VARCHAR(255)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY
	,CategoryName NVARCHAR(50) NOT NULL
	,Notes VARCHAR(255)
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY
	,Title NVARCHAR(50) NOT NULL
	,DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL
	,CopyrightYear INT
	,[Length] INT
	,GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,Rating DECIMAL(18, 2)
	,Notes VARCHAR(255)
)

INSERT INTO Directors(DirectorName, Notes)
	VALUES	
				('Ivan Shepelev', NULL)
				,('Stiliyan Iliev', NULL)
				,('Bogdan Slavchev', NULL)
				,('Zori Karachanova', NULL)
				,('Emiliya Eseva', NULL)

INSERT INTO Genres(GenreName, Notes)
	VALUES
				('Comedy', NULL)
				,('Romantic', NULL)
				,('Drama', NULL)
				,('Crime', NULL)
				,('Action', NULL)

INSERT INTO Categories(CategoryName, Notes)
	VALUES
				('Fiction', NULL)
				,('Non-Fiction', NULL)
				,('Animated', NULL)
				,('Documentary', NULL)
				,('Short', NULL)

INSERT INTO Movies(Title, DirectorId, GenreId, CategoryId)
	VALUES
				('The Shawshank Redemption', 2, 3, 1)
				,('The Dark Knight', 1, 5, 1)
				,('Pulp Fiction', 3, 4, 1)
				,('Eternal Sunshine of the Spotless Mind', 4, 2, 1)
				,('The Lord of the Rings: The Fellowship of the Ring', 5, 5, 1)
