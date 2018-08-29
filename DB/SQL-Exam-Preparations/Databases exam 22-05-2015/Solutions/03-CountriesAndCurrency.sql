SELECT CountryName
	,CountryCode
	,CAST(CASE 
			WHEN CurrencyCode = 'EUR'
				THEN 'Inside'
			ELSE 'Outside'
			END AS NVARCHAR) AS Eurozone
FROM Countries
ORDER BY CountryName
