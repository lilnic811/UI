USE music;

GO
CREATE OR ALTER PROCEDURE dbo.mostPlaylisted_proc
AS
BEGIN
SELECT TOP 10
	S.SongName
	,M.MusicianName
	,COUNT(*) AS Appearances
	FROM dbo.PlaylistSongs PS
		INNER JOIN dbo.Songs S ON S.SongID = PS.SongID
		INNER JOIN dbo.Albums A ON A.AlbumID =S.AlbumID
		INNER JOIN dbo.Musicians M ON M.MusicianID = A.MusicianID
GROUP BY S.SongName, M.MusicianName
ORDER BY Appearances DESC

END;



--EXEC dbo.topCharts_proc