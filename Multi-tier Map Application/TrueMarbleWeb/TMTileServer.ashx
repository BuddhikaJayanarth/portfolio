<%@ WebHandler Language="C#" Class="TMTileServer" %>

using System;
using System.Web;
using TrueMarbleBiz;
using System.ServiceModel;
using System.Windows.Forms;

public class TMTileServer : IHttpHandler , ITMBizControllerCallback {



    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        TrueMarbleBiz.TMBizController m_biz;
        NetTcpBinding tcpBinding = new NetTcpBinding();
        tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;
        tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;

        ChannelFactory<TMBizController> tmDataFactory;
        string surl = "net.tcp://localhost:50002/TMBiz";

        tmDataFactory = new DuplexChannelFactory<TMBizController>(this, tcpBinding, surl);

        m_biz = tmDataFactory.CreateChannel();

        int x = Convert.ToInt32(context.Request["x"]);
        int y = Convert.ToInt32(context.Request["y"]);
        int zoom = Convert.ToInt32(context.Request["zoom"]);
//                        MessageBox.Show(zoom+" "+x+" "+y);
//        Console.WriteLine("the zoom"+zoom);
        if (zoom > 6 || zoom < 0 )
        {
            MessageBox.Show("Invalid Zoom");
        }
        else
        {
            try
            {
                int maxx = m_biz.GetNumTilesAcross(zoom);
                int maxy = m_biz.GetNumTilesDown(zoom);

                if (x <= maxx && x > -1)
                {
                    if (y <= maxy && y > -1)
                    {
                        byte[] imagebuff = m_biz.LoadTile(zoom, x, y);
                        context.Response.Clear();
                        context.Response.ClearHeaders();
                        context.Response.ContentType = "image/jpeg";
                        context.Response.BinaryWrite(imagebuff);
                        context.Response.End();

                    }
                }
            }
            catch
            {

            }
        }
    }

    public void OnVerificationComplete(bool x)
    {

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}