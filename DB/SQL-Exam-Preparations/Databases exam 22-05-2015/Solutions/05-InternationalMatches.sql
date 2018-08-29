SELECT c.CountryName AS [Home Team]
	,a.CountryName AS [Away Team]
	,i.MatchDate AS [Match Date]
FROM Countries c
INNER JOIN InternationalMatches i ON c.CountryCode = i.HomeCountryCode
INNER JOIN Countries a ON a.CountryCode = i.AwayCountryCode
ORDER BY [Match Date] DESC