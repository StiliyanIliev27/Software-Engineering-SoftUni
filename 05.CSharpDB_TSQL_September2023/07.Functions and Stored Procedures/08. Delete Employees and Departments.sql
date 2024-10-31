CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@DepartmentId INT) 
AS
BEGIN
	DECLARE @employeesToBeDeleted TABLE (ID INT)

	INSERT INTO @employeesToBeDeleted(ID)
	SELECT EmployeeID
	From Employees
	WHERE DepartmentID = @DepartmentId

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT * FROM @employeesToBeDeleted)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT * FROM @employeesToBeDeleted)

	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (SELECT * FROM @employeesToBeDeleted)

	DELETE FROM Employees
	WHERE DepartmentID = @DepartmentId

	DELETE FROM Departments
	WHERE DepartmentID = @DepartmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @DepartmentId
END