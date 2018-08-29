SELECT
	i.Name AS [Item],
	i.Price,
	i.MinLevel,
	gt.Name AS [Forbidden Game Type]
FROM Items i
FULL JOIN GameTypeForbiddenItems gfi
	ON gfi.ItemId = i.Id
FULL JOIN GameTypes gt
	ON gfi.GameTypeId = gt.Id
ORDER BY [Forbidden Game Type] DESC, [Item] ASC