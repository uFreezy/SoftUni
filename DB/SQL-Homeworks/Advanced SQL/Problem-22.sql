INSERT INTO Users (Username,Password,Fullname,Lastlogin)
SELECT Username,
       Password,
       Fullname,
       LastLogin
FROM
  ( SELECT LOWER(SUBSTRING(e.FirstName, 1, 1) + e.LastName) AS [Username],
           LOWER(REPLACE(CONVERT(char(6), SUBSTRING(e.FirstName, 1, 1) + e.LastName), ' ', '1')) AS [Password],
           e.FirstName + e.LastName AS [Fullname],
           NULL AS LastLogin,
           ROW_NUMBER() OVER(PARTITION BY LOWER(SUBSTRING(e.FirstName, 1, 1) + e.LastName)
                             ORDER BY FirstName) AS rowNumber
   FROM Employees e) AS uniqueUsers
WHERE uniqueUsers.rowNumber = 1