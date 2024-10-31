CREATE OR ALTER FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(255))
RETURNS TABLE
AS
RETURN (
	SELECT SUM(Cash) AS SumCash FROM
		(SELECT 
			ug.GameId
			,ug.Cash
			,ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNum
		FROM UsersGames ug
			JOIN Games g ON g.Id = ug.GameId
		WHERE g.[Name] = @GameName
		GROUP BY ug.GameId, ug.Cash
		) AS RankedData
		
		WHERE RowNum % 2 = 1
)	