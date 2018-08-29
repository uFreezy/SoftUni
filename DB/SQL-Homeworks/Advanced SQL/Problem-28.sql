SELECT t.Name AS Town,
       COUNT(*) AS [Employees Count]
FROM
  (SELECT e.FirstName,
          e.LastName,
          e.AddressID
   FROM Employees e,
        Employees m
   WHERE e.EmployeeID = m.ManagerID
   GROUP BY e.FirstName,
            e.LastName,
            e.AddressID) e
INNER JOIN Addresses a ON e.AddressID = a.AddressID
INNER JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name