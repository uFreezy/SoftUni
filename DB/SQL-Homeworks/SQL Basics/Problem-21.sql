SELECT e.* , d.FirstName + ' ' + d.LastName AS Manager, a.*
FROM Employees e, Employees d, Addresses a 
WHERE e.ManagerID = d.EmployeeID