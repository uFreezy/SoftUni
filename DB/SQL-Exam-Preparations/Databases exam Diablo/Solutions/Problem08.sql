SELECT
	u.Username AS [Username],
	g.Name AS [Game],
	COUNT(ugi.UserGameId) AS [Items Count],
	SUM(i.Price) AS [Items Price]
FROM Users u
INNER JOIN UsersGames ug
	ON u.Id = ug.UserId
INNER JOIN Games g
	ON g.Id = ug.GameId
INNER JOIN UserGameItems ugi
	ON ugi.UserGameId = ug.Id
INNER JOIN Items i
	ON ugi.ItemId = i.Id

GROUP BY	u.Username,
			g.Name
HAVING COUNT(ugi.UserGameId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, [Username] ASC