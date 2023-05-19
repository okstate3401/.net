CREATE PROCEDURE [dbo].[SearchArtists]
	@search nvarchar(150) = ''
AS
BEGIN
	SELECT artistID, title, biography, imageURL, heroURL 
	FROM Artist 
	WHERE title LIKE '%' + @search + '%'
END
