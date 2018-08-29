CREATE PROCEDURE usp_FullNames AS
SELECT FirstName + ' ' + LastName AS FullName
FROM Persons GO