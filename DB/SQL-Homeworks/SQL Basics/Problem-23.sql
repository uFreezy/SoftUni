SELECT  e.*, m.FirstName + ' ' + m.LastName AS Manager
FROM Employees e LEFT OUTER JOIN Employees m
ON e.EmployeeID = m.ManagerID