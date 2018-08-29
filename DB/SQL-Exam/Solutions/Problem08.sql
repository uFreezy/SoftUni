SELECT
	m.Name,
	(SELECT
			SUM(Price)
		FROM Lenses
		WHERE ManufacturerId = m.Id)
	AS [Total Price]
FROM Manufacturers m
WHERE (SELECT
		SUM(Price)
	FROM Lenses
	WHERE ManufacturerId = m.Id)
IS NOT NULL
ORDER BY m.Name