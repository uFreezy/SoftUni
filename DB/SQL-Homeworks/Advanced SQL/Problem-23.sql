UPDATE Users
SET Password = NULL
WHERE DATEDIFF(DAY, Lastlogin, CAST('10.03.2010' AS datetime)) >= 0
  OR Lastlogin IS NULL