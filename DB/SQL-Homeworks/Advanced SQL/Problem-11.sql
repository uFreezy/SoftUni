SELECT m.firstname AS [First Name],
       m.lastname  AS [Last Name],
       Count(*)    AS [Employees Count]
FROM   employees e
       JOIN employees m
         ON ( e.managerid = m.employeeid )
GROUP  BY m.firstname,
          m.lastname
HAVING Count(*) = 5 