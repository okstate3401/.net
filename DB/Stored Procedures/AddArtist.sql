CREATE PROCEDURE [dbo].[AddArtist]
	@title varchar(150),
	@biography varchar(MAX),
	@imageUrl varchar(500),
	@heroUrl varchar(500)
AS
	INSERT INTO Artist (title, biography, imageURL, heroURL)
	VALUES (@title, @biography, @imageUrl, @heroUrl);
RETURN @@Identity
