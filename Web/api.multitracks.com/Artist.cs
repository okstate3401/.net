namespace api.multitracks.com
{
    public class Artist
    {
        public int? ArtistId { get; set; }
        public string Title { get; set; }   
        public string Biography { get; set; }
        public string ImageUrl { get; set; }
        public string HeroUrl { get; set; }

        public Artist(int? artistId, string title, string biography, string imageUrl, string heroUrl) 
        { 
            ArtistId = artistId;
            Title = title;
            Biography = biography;
            ImageUrl = imageUrl;
            HeroUrl = heroUrl;
        }
    }
}
