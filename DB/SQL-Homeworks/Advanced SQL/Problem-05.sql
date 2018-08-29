SELECT Avg(salary) AS [Average Salary For Sales]
FROM   employees,
       departments
WHERE  NAME = 'Sales' 