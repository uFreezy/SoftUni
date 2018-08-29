SELECT
	Name,
	[Description] =
					CASE
						WHEN [Description] IS NOT NULL THEN [Description]
						WHEN [Description] IS NULL THEN 'No description'
					END
FROM Albums
ORDER BY Name