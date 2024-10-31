CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan (@Number MONEY)
AS
BEGIN
	SELECT 
		FirstName AS [First Name]
		,LastName AS [Last Name]
	FROM AccountHolders ah
		JOIN Accounts a ON a.AccountHolderId = ah.Id
	GROUP BY ah.Id, ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @Number
	ORDER BY FirstName, LastName
END