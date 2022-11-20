USE music;

GO
CREATE OR ALTER PROCEDURE dbo.avgUserPlaylistRating_proc(
@userID BIGINT
)
AS
BEGIN

SELECT 
	SUM (R.Rating) / COUNT(R.UserRatingID) AS AvgRating
	FROM dbo.Playlists P
	INNER JOIN dbo.PlaylistSongs PS ON PS.PlaylistID = P.PlaylistID
	INNER JOIN dbo.Songs S ON S.SongID = PS.SongID
	INNER JOIN dbo.UserRatings R ON R.SongID = S.SongID
WHERE P.PlaylistID = @playlistID

END;





GO
CREATE OR ALTER PROCEDURE dbo.topCharts_proc
AS
BEGIN
SELECT TOP 50
	S.SongName
	,M.MusicianName
	--,SUM (R.Rating) / COUNT(*) AS AvgRating
	FROM dbo.UserRatings R 
		INNER JOIN dbo.Songs S ON S.SongID = R.SongID
		INNER JOIN dbo.Albums A ON A.AlbumID =S.AlbumID
		INNER JOIN dbo.Musicians M ON M.MusicianID = A.MusicianID
GROUP BY S.SongName, M.MusicianName
ORDER BY SUM (R.Rating) / COUNT(*) DESC

END;

--EXEC dbo.topCharts_proc






GO
CREATE OR ALTER PROCEDURE dbo.genreBreakdown_proc(
@userID BIGINT
)
AS
BEGIN

SELECT 
	SUM (R.Rating) / COUNT(*) AS AvgRating
	FROM dbo.Users U
	INNER JOIN dbo.Playlists P ON P.UserID = U.UserID
	INNER JOIN dbo.PlaylistSongs PS ON PS.PlaylistID = P.PlaylistID
	LEFT JOIN dbo.Songs S ON S.SongID = PS.SongID
	JOIN dbo.UserRatings R ON R.SongID = S.SongID
WHERE U.UserID = 101
GROUP BY U.UserID

END;
