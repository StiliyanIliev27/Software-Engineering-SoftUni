SELECT DepartmentID, Salary AS ThirdHighestSalary FROM 
	(SELECT 
	Salary
	,DepartmentID
	,MAX(Salary) AS MaxSalary
	,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRanking
		FROM Employees
		GROUP BY DepartmentID, Salary) AS CoreQuery
WHERE CoreQuery.SalaryRanking = 3