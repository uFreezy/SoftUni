SELECT TOP 0 *
INTO   #mytemptablee
FROM   Employeesprojects

DROP TABLE Employeesprojects

SELECT *
INTO   Employessprojects
FROM   #mytemptablee

DROP TABLE #mytemptablee 