CREATE VIEW loggedtoday
AS
  SELECT *
  FROM   users
  WHERE  CONVERT(VARCHAR(10), lastlogin, 10) =
         CONVERT(VARCHAR(10), Getdate(), 10) 