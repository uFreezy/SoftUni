SELECT e.firstname + ' ' + e.lastname AS [FullName],
       e.salary,
       d.NAME                         AS Department
FROM   employees e
       JOIN departments d
         ON e.departmentid = d.departmentid
WHERE  e.salary = (SELECT Min(salary)
                   FROM   employees
                   WHERE  departmentid = d.departmentid) 