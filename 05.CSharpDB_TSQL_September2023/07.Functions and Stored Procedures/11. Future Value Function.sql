CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(18, 2), @InterestRate FLOAT, @Years INT)
RETURNS DECIMAL(20, 4)
AS
BEGIN
	RETURN @SUM * POWER((1 + @InterestRate), @Years)
END