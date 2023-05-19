using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace api.multitracks.com.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController
    {
        [Route("List")]
        [HttpGet]
        public PaginationResults GetSongs(int currentPageNumber, int pageSize)
        {
            int offsetRowNum = pageSize * (currentPageNumber - 1);

            SQL sql = new SQL();
            sql.Parameters.Add("@offset", offsetRowNum);
            sql.Parameters.Add("@fetchNext", pageSize);
            var data = sql.ExecuteStoredProcedureDS("GetSongs");

            List<Song> songs = new List<Song>();

            foreach (DataRow r in data.Tables[0].Rows)
            {
                songs.Add(new Song(r["albumTitle"] + "", r["artistTitle"] + "", r["songTitle"] + "", Convert.ToDouble(r["bpm"]), r["timeSignature"] + "", Convert.ToBoolean(r["multitracks"]), Convert.ToBoolean(r["customMix"]), Convert.ToBoolean(r["chart"]), Convert.ToBoolean(r["rehearsalMix"]), Convert.ToBoolean(r["patches"]), Convert.ToBoolean(r["proPresenter"])));
            }

            int totalCnt = 0;

            if (data.Tables[0].Rows.Count > 0) 
            {
                DataRow r = data.Tables[0].Rows[0];
                totalCnt = Convert.ToInt32(r["totalCnt"]);
            }


            return new PaginationResults
            {
                CurrentPageNum = currentPageNumber,
                PageSize = pageSize,
                Songs = songs,
                PageCount = (totalCnt - 1) / pageSize + 1,
                TotalCount = totalCnt
            };
        }
    }
}
