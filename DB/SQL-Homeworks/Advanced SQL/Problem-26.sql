SELECT d.Name AS Department,
       e.JobTitle,
       e.FirstName,
       e.Salary AS MinSalary
FROM employees e
JOIN departments d ON e.departmentid = d.departmentid
WHERE e.salary =
    (SELECT Min(salary)
     FROM employees
     WHERE JobTitle = e.JobTitle)
ORDER BY Department