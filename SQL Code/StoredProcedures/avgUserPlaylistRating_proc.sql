USE music;

GO
CREATE OR ALTER PROCEDURE dbo.genreBreakdown_proc(
@userID BIGINT
)
AS
BEGIN

SELECT 
	--SUM (CAST(R.Rating AS DECIMAL(3,2)))
	CAST(SUM (CAST(R.Rating AS DECIMAL(3,2))) / COUNT(*) AS DECIMAL(2,1)) AS AvgRating
	FROM dbo.Users U
	INNER JOIN dbo.Playlists P ON P.UserID = U.UserID
	INNER JOIN dbo.PlaylistSongs PS ON PS.PlaylistID = P.PlaylistID
	LEFT JOIN dbo.Songs S ON S.SongID = PS.SongID
	JOIN dbo.UserRatings R ON R.SongID = S.SongID
WHERE U.UserID = @userID
GROUP BY U.UserID

END;
