SELECT d.Name,
       e.JobTitle,
       e.Salary
FROM Employees e,
     Departments d
GROUP BY d.Name,
         e.JobTitle,
         e.Salary