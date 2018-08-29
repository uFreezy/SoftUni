SELECT e.FirstName + ' ' + e.LastName AS Name 
	FROM Employees e
	WHERE (SELECT Name FROM Departments WHERE DepartmentID = e.DepartmentID) IN ('Sales','Finance') 
	AND HireDate BETWEEN '1995-01-01 00:00:00' AND '2005-01-01 00:00:00'