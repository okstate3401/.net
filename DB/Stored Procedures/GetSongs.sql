CREATE PROCEDURE [dbo].[GetSongs]
	@offset int,
	@fetchNext int
AS
BEGIN
	SELECT al.title [albumTitle], ar.title [artistTitle], Song.title [songTitle], Song.bpm, Song.timeSignature, Song.multitracks, Song.customMix, Song.chart, Song.rehearsalMix, Song.patches, Song.proPresenter,
	(SELECT COUNT(Song.songID) FROM Song) [totalCnt]
	FROM Song
	INNER JOIN Album al ON al.albumID = song.albumID
	INNER JOIN Artist ar ON ar.artistID = song.artistID
	ORDER BY Song.title
	OFFSET @offset ROWS FETCH NEXT @fetchNext ROWS ONLY
END
