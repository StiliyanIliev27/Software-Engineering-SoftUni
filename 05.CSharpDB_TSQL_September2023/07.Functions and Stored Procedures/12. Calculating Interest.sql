CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT)
AS
BEGIN
	DECLARE @years INT = 5

	SELECT 
		ah.Id AS [Account Id]
		,FirstName AS [First Name]
		,LastName AS [Last Name]
		,a.Balance AS [Current Balance]
		,dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, @years) AS [Balance in 5 years]
	FROM AccountHolders ah
		JOIN Accounts a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @AccountId
END