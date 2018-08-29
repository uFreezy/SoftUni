BEGIN TRAN

DELETE e
FROM   Employees e
       INNER JOIN Employees m
               ON e.Managerid = m.Employeeid
       INNER JOIN Departments d
               ON m.Departmentid = d.Departmentid
WHERE  d.NAME = 'Sales'

ALTER TABLE Employees
  DROP CONSTRAINT fk_employees_departments

ALTER TABLE Departments
  DROP CONSTRAINT fk_departments_employees

DELETE FROM Employees
WHERE  Departmentid = 3

ROLLBACK TRAN 