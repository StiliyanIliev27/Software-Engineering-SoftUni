SELECT * FROM
(SELECT
	DepartmentID
	,MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID) AS CoreQuery
WHERE MaxSalary < 30000 OR MaxSalary > 70000