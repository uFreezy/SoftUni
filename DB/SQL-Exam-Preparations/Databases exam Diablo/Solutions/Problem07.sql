SELECT
	g.Name AS [Game],
	gt.Name AS [Game Type],
	u.Username AS [Username],
	ug.Level AS [Level],
	ug.Cash AS [Cash],
	c.Name AS [Character]
FROM Users u
INNER JOIN UsersGames ug
	ON u.Id = ug.UserId
INNER JOIN Games g
	ON g.Id = ug.GameId
INNER JOIN GameTypes gt
	ON gt.Id = g.GameTypeId
INNER JOIN Characters c
	ON ug.CharacterId = c.Id
ORDER BY [Level] DESC, [Username], [Game]