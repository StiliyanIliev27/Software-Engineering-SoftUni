SELECT TOP(10)
	FirstName
	,LastName
	,DepartmentID
FROM Employees ex
WHERE Salary > 
(	
	SELECT AVG(Salary) AS AverageSalary
	FROM Employees ein
	WHERE ein.DepartmentID = ex.DepartmentID
	GROUP BY DepartmentID
)