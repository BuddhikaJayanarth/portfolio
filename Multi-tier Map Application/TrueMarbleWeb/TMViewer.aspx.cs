using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    int y = 0;
    int x = 0;
    int Zoom = 0;
    string path;
    protected void Page_Load(object sender, EventArgs e)
    {
        load();
    }

    protected void btnIn_ServerClick(object sender, EventArgs e)
    {
        Zoom = Convert.ToInt32(displayZoom.Value);
        Zoom--;
        displayZoom.Value = Zoom.ToString();
        x = 0;
        y = 0;

        txtX.Value = x.ToString();
        txtY.Value = y.ToString();
        load();
    }

    protected void btnOut_ServerClick(object sender, EventArgs e)
    {
        Zoom = Convert.ToInt32(displayZoom.Value);
        Zoom++;
        displayZoom.Value = Zoom.ToString();
        x = 0;
        y = 0;

        txtX.Value = x.ToString();
        txtY.Value = y.ToString();
        load();
    }
    protected void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        load();
    }

    protected void btnNorth_ServerClick(object sender, EventArgs e)
    {

        y = Convert.ToInt32(txtY.Value);
        y--;

        txtY.Value = y.ToString();
        load();
    }

    protected void btnSouth_ServerClick(object sender, EventArgs e)
    {

        y = Convert.ToInt32(txtY.Value);
        y++;

        txtY.Value = y.ToString();
        load();
    }

    protected void btnEast_ServerClick(object sender, EventArgs e)
    {

        x = Convert.ToInt32(txtX.Value);
        x++;

        txtX.Value = x.ToString();

        load();
    }

    protected void btnWest_ServerClick(object sender, EventArgs e)
    {

        x = Convert.ToInt32(txtX.Value);
        x--;

        txtX.Value = x.ToString();

        load();
    }

    public void load()
    {

        x = Convert.ToInt32(txtX.Value);
        y = Convert.ToInt32(txtY.Value);
        //strX = x.ToString("000");
        //strY = y.ToString("000");
        //strZ = zoomPath.ToString("000");

        path = "TMTileServer.ashx?zoom="+Zoom+"&x="+x+"&y="+y+"";
        imgTile.Attributes["src"] = path;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}