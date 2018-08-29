CREATE TABLE WorkHoursLogs
(
    Id INT PRIMARY KEY IDENTITY NOT NULL,
	Message NVARCHAR(50) NOT NULL,
	DateOfChange DATETIME NOT NULL
)

GO

CREATE TRIGGER  tr_WorkHoursInsert 
ON WorkHours
FOR INSERT
AS 
	INSERT INTO WorkHoursLogs (Message, DateOfChange)
	VALUES('Added row', GETDATE())
GO

CREATE TRIGGER  tr_WorkHoursDelete 
ON WorkHours
FOR DELETE
AS 
	INSERT INTO WorkHoursLogs (Message, DateOfChange)
	VALUES('Deleted row', GETDATE())

GO

CREATE TRIGGER  tr_WorkHoursUpdate
ON WorkHours
 FOR UPDATE
AS 
	INSERT INTO WorkHoursLogs (Message, DateOfChange)
	VALUES('Update row', GETDATE())

GO

INSERT INTO WorkHours (EmployeeId, onDate, Task, Hours)
	VALUES(10, GETDATE(), 'INSERT TEST', 10)

INSERT INTO WorkHours (EmployeeId, onDate, Task, Hours)
	VALUES(11, GETDATE(), 'Test', 100)

DELETE WorkHours
WHERE EmployeeId = 10

UPDATE WorkHours
SET Task = 'UPDATE TEST'
WHERE EmployeeId = 11

SELECT * FROM WorkHoursLogs