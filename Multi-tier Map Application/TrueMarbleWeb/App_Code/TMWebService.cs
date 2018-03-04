using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TrueMarbleBiz;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TMWebService" in code, svc and config file together.
public class TMWebService : ITMWebService, ITMBizControllerCallback
{
    TMBizController itm_con;

    public TMWebService()
    {
        NetTcpBinding tcpBinding = new NetTcpBinding();
        tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;
        tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;

        ChannelFactory<TMBizController> tmDataFactory;
        string surl = "net.tcp://localhost:50002/TMBiz";

        tmDataFactory = new DuplexChannelFactory<TMBizController>(this, tcpBinding, surl);

        itm_con = tmDataFactory.CreateChannel();
    }

    public int GetNumTilesAcross(int zoom)
    {
        return itm_con.GetNumTilesAcross(zoom);
    }

    public int GetNumTilesDown(int zoom)
    {
        return itm_con.GetNumTilesDown(zoom);
    }
    public void OnVerificationComplete(bool x)
    {

    }
}
