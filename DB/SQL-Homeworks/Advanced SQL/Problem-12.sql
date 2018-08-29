SELECT e.firstname + ' ' + e.lastname
       AS
       [Employee],
       Isnull(CONVERT(NVARCHAR(50), m.firstname + ' ' + m.lastname),
       'No manager') AS
       Manager
FROM   employees e
       LEFT OUTER JOIN employees m
                    ON ( e.managerid = m.employeeid ) 