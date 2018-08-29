SELECT t.Name AS Town,
       COUNT(*) AS [Employees Count]
FROM Employees e
INNER JOIN Addresses a ON e.AddressID = a.AddressID
INNER JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC