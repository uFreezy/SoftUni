SELECT firstname + ' ' + lastname AS FullName,
       salary
FROM   employees
WHERE  salary = (SELECT Avg(salary)
                 FROM   employees
                 WHERE  departmentid = 1) 