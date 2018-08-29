SELECT
	l.[Type],
	COUNT(l.[Type]) AS [Count]
FROM Lenses l
GROUP BY l.[Type]
ORDER BY [Count] DESC, l.[Type] ASC