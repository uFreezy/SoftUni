SELECT
	u.Username,
	u.FullName,
	u.Birthdate AS [BirthDate],
	'Photo' =
				CASE
					WHEN p.Title IS NOT NULL THEN p.Title
					WHEN p.Title IS NULL THEN 'No photos'
				END
FROM Users u
FULL JOIN Photographs p
	ON p.UserId = u.Id
WHERE MONTH(u.Birthdate) = 1
ORDER BY u.FullName ASC