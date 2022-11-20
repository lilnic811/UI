USE music;

GO
CREATE OR ALTER PROCEDURE dbo.averageRating_proc(
@userID BIGINT
)
AS
BEGIN
SELECT 
	G.GenreName
	,COUNT(*) AS songCount
	FROM dbo.Users U
	INNER JOIN dbo.Playlists P ON P.UserID = U.UserID
	INNER JOIN dbo.PlaylistSongs PS ON PS.PlaylistID = P.PlaylistID
	INNER JOIN dbo.Songs S ON S.SongID = PS.SongID
	INNER JOIN dbo.Albums A ON A.AlbumID = S.AlbumID
	INNER JOIN dbo.Genre G ON G.GenreID = A.GenreID
WHERE U.UserID = @userID
GROUP BY G.GenreName

END;


