CREATE OR ALTER PROCEDURE usp_GetEmployeesFromTown (@Town NVARCHAR(50))
AS
BEGIN
	SELECT 
		e.FirstName AS [First Name]
		,e.LastName AS [Last Name]
	FROM Employees e
		JOIN Addresses a ON a.AddressID = e.AddressID
		JOIN Towns t ON t.TownID = a.TownID
	WHERE t.[Name] = @Town
END