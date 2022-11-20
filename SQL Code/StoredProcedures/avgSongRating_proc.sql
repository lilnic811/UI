USE music;

GO
CREATE OR ALTER PROCEDURE dbo.averageRating_proc(
@songID BIGINT
)
AS
BEGIN
SELECT 
	SUM (R.Rating) / COUNT(*) AS AvgRating
	FROM dbo.Playlists P
	INNER JOIN dbo.PlaylistSongs PS ON PS.PlaylistID = P.PlaylistID
	INNER JOIN dbo.Songs S ON S.SongID = PS.SongID
	INNER JOIN dbo.UserRatings R ON R.SongID = S.SongID
WHERE S.SongID = @songID

END;


--DECLARE @svt BIGINT = (SELECT S.SongID FROM dbo.Songs S WHERE S.SongName = 'Lilili Yabbay')
--EXEC dbo.averageRating_proc @songID = @svt

