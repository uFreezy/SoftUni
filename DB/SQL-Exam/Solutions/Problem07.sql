SELECT
	m.Name,
	c.Model,
	c.Price
FROM Manufacturers m
INNER JOIN Cameras c
	ON c.ManufacturerId = m.Id
WHERE c.Price > (SELECT
		AVG(Price)
	FROM Cameras)
ORDER BY c.Price DESC, c.Model ASC