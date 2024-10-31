CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel(@SalaryLevel VARCHAR(10))
AS
BEGIN
	SELECT
		FirstName AS [First Name]
		,LastName AS [Last Name]
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
END