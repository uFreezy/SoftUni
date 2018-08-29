ALTER TABLE Employees
ADD [Full Email Addresses] NVARCHAR(50) NOT NULL
CONSTRAINT Constraint_name DEFAULT 0 WITH VALUES


UPDATE Employees
SET [Full Email Addresses] = FirstName + '.' + LastName + '@softuni.bg'
WHERE [Full Email Addresses] = 0