USE music;

GO
CREATE OR ALTER PROCEDURE dbo.topCharts_proc
AS
BEGIN
SELECT TOP 50
	S.SongName
	,M.MusicianName
	,SUM (R.Rating) / COUNT(*) AS AvgRating
	FROM dbo.UserRatings R 
		INNER JOIN dbo.Songs S ON S.SongID = R.SongID
		INNER JOIN dbo.Albums A ON A.AlbumID =S.AlbumID
		INNER JOIN dbo.Musicians M ON M.MusicianID = A.MusicianID
GROUP BY S.SongName, M.MusicianName
ORDER BY AvgRating DESC

END;

--EXEC dbo.topCharts_proc