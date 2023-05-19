using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace api.multitracks.com.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController
    {
        [Route("Search")]
        [HttpGet]
        public List<Artist> SearchArtists(string? search)
        {
            List<Artist> artists = new List<Artist>();
            SQL sql = new SQL();
            sql.Parameters.Add("@search", search);
            var data = sql.ExecuteStoredProcedureDS("SearchArtists");

            foreach(DataRow r in data.Tables[0].Rows)
            {
                artists.Add(new Artist(Convert.ToInt32(r["artistId"]), r["title"] + "", r["biography"] + "", r["imageURL"] + "", r["heroURL"] + ""));
            }

            return artists;
        }

        [Route("Add")]
        [HttpPost]
        public bool AddArtist(Artist artist)
        {
            SQL sql = new SQL();
            sql.Parameters.Add("@title", artist.Title);
            sql.Parameters.Add("@biography", artist.Biography);
            sql.Parameters.Add("@imageUrl", artist.ImageUrl);
            sql.Parameters.Add("@heroUrl", artist.HeroUrl);
            int numRowsAffected = sql.ExecuteStoredProcedure("AddArtist");

            // return if query was successful
            return numRowsAffected == 1;
        }
    }
}
