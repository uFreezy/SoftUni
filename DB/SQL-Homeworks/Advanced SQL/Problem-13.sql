SELECT e.firstname AS [First Name],
       m.firstname AS Manager
FROM   employees e
       LEFT OUTER JOIN employees m
                    ON ( e.managerid = m.employeeid )
WHERE  Len(e.lastname) = 5 