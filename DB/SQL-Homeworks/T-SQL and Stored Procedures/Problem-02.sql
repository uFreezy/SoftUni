CREATE PROCEDURE usp_FindPersonsWithBalance @Balance int AS
SELECT p.FirstName,
       p.LastName,
       p.SSN
FROM Persons p
INNER JOIN Accounts a ON p.Id = a.PersonID
WHERE a.Balance > @Balance GO