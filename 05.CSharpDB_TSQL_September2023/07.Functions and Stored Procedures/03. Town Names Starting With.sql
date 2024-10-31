CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith (@FirstLetter NVARCHAR(20))
AS
BEGIN
	SELECT 
		[Name]
	FROM Towns
	WHERE [Name] LIKE @FirstLetter + '%'
END