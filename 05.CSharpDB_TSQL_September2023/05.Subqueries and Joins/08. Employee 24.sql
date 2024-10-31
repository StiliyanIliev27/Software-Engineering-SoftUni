SELECT 
	 e.EmployeeID
	,FirstName
		,CASE
			WHEN p.StartDate > '2004-12-31' THEN NULL 
			ELSE p.[Name]
		END AS ProjectName
FROM Employees e
	JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24