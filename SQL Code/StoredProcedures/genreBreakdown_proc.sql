USE music;

GO
CREATE OR ALTER PROCEDURE dbo.genreBreakdown_proc(
@userID BIGINT
)
AS
BEGIN

DECLARE @songCount DECIMAL(4,2) = (SELECT COUNT(*) 
		FROM dbo.PlaylistSongs PS 
		INNER JOIN dbo.Playlists P ON P.PlaylistID = PS.PlaylistID
		INNER JOIN dbo.Users U ON U.UserID = P.UserID
		WHERE U.UserID = @userID)
print(@songCount)

SELECT 
	G.GenreName
	--,COUNT(*) AS songCount
	,CAST(COUNT(*) / @songCount * 100 AS DECIMAL (4, 2)) AS Proportion
	FROM dbo.Users U
	INNER JOIN dbo.Playlists P ON P.UserID = U.UserID
	INNER JOIN dbo.PlaylistSongs PS ON PS.PlaylistID = P.PlaylistID
	INNER JOIN dbo.Songs S ON S.SongID = PS.SongID
	INNER JOIN dbo.Albums A ON A.AlbumID = S.AlbumID
	INNER JOIN dbo.Genre G ON G.GenreID = A.GenreID
WHERE U.UserID = @userID
GROUP BY G.GenreName
ORDER BY Proportion DESC

END;


