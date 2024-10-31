SELECT TOP(3)
	  e.EmployeeID
	  , FirstName
FROM Employees e
WHERE e.EmployeeID NOT IN
	(SELECT EmployeeID FROM EmployeesProjects)
ORDER BY e.EmployeeID