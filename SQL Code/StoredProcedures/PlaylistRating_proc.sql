USE music;

GO
CREATE PROCEDURE averageRating_proc
(@playlistID BIGINT)
AS

SELECT * FROM dbo.Playlists P
INNER JOIN dbo.PlaylistSongs PS ON PS.PlaylistID = P.PlaylistID
INNER JOIN dbo.Songs S ON S.SongID = PS.SongID
INNER JOIN dbo.UserRatings R ON R.SongID = S.SongID
WHERE S.SongName ='Lilili Yabbay'

SELECT * FROM dbo.UserRatings U
INNER JOIN dbo.Songs S ON S.SongID = U.SongID
INNER JOIN dbo.Albums A ON A.AlbumID = S.AlbumID
INNER JOIN dbo.Musicians M ON M.MusicianID = A.MusicianID
ORDER By S.SongID



GO;




USE music;

GO
CREATE OR ALTER PROCEDURE dbo.averageRating_proc(
@playlistID BIGINT
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

