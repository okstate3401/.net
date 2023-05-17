CREATE PROCEDURE dbo.GetArtistDetails
	@artistId INT = 1
AS
BEGIN

	SELECT ar.heroURL [artistHeroUrl], ar.imageURL [artistImageUrl], ar.title [artistTitle], ar.biography [artistBiography], 
	al.albumID, al.imageURL [albumImageUrl], al.title [albumTitle], s.title [songTitle], s.bpm [songBPM], s.timeSignature [songTimeSignature]
	FROM Artist ar
	INNER JOIN Album al ON al.artistID = ar.artistID
	INNER JOIN Song s ON s.albumID = al.albumID AND s.artistID = ar.artistID
	WHERE ar.artistID = @artistId

END