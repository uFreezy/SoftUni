SELECT e.* , d.FirstName + ' ' + d.LastName AS Manager 
FROM Employees e, Employees d 
WHERE e.ManagerID = d.EmployeeID