SELECT
	p.Title,
	a.Name
FROM AlbumsPhotographs ap
INNER JOIN Albums a
	ON a.Id = ap.AlbumId
INNER JOIN Photographs p
	ON p.Id = ap.PhotographId
ORDER BY a.Name ASC, p.Title DESC