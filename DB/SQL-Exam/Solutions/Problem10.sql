SELECT
	u.Username,
	u.FullName
FROM Users u
ORDER BY LEN(u.Username + u.FullName) ASC, u.Birthdate DESC