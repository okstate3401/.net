using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

public partial class artistDetails : MultitracksPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();

        try
        {
            // get artist id from url parameters
            string urlParamArtistId = Request["artistID"] + "";

            int artistId;
            int.TryParse(urlParamArtistId, out artistId);

            // default if no url param is given
            if(artistId == 0)
                artistId = 1;

            sql.Parameters.Add("@artistId", artistId);
            var data = sql.ExecuteStoredProcedureDT("GetArtistDetails");

            songs.DataSource = data;
            songs.DataBind();

            // Select only unique albums - query could return duplicates if there are multiple songs in an album
            DataTable dtAlbums = data.Rows.Cast<DataRow>().GroupBy(r => r.Field<int>("albumID"), (key, group) => group.First()).CopyToDataTable();
            albums.DataSource = dtAlbums;
            albums.DataBind();

            // We only need the first row to fill this information
            DataTable dtFirstRow = data.Clone();
            dtFirstRow.ImportRow(data.FirstOrNewRow());
            artistHeaderInfo.DataSource = dtFirstRow;
            artistHeaderInfo.DataBind();

            artistBiography.DataSource = dtFirstRow;
            artistBiography.DataBind();
        }
        catch
        {
            // artist not found
        }
    }
}