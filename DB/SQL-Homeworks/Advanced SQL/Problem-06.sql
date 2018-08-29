SELECT Count(*) AS [Sales Employees Count]
FROM   employees,
       departments
WHERE  NAME = 'Sales' 