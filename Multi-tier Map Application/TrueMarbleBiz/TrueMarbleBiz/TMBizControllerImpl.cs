using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TrueMarbleData;

namespace TrueMarbleBiz
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]

    internal class TMBizControllerImpl : TMBizController
    {
        private TrueMarbleData.ITMDataController m_tmData;
        private BrowseHistory BH;
        private HistEntry His;
        TMBizControllerImpl()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;
            tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;

            ChannelFactory<ITMDataController> tmDataFactory;
            string surl = "net.tcp://localhost:5001/TMData";

            tmDataFactory = new ChannelFactory<ITMDataController>(tcpBinding, surl);

            m_tmData = tmDataFactory.CreateChannel();

            BH = new BrowseHistory();

            Console.WriteLine("It started here");

        }

        public int GetTileWidth()
        {
            int w;
            w = m_tmData.GetTileWidth();
            return w;
        }

        public int GetTileHeight()
        {
            int h;
            h = m_tmData.GetTileHeight();
            return h;
        }

        public int GetNumTilesAcross(int zoom)
        {
            int x;
            x = m_tmData.GetNumTilesAcross(zoom);
            return x;
        }

        public int GetNumTilesDown(int zoom)
        {
            int x;
            x = m_tmData.GetNumTilesDown(zoom);
            return x;
        }

        public byte[] LoadTile(int zoom, int x, int y)
        {

            byte[] imageBuf;
            imageBuf = m_tmData.LoadTile(zoom, x, y);
            return imageBuf;

        }

        public bool VerifyTiles()
        {

            int zoom;
            int x;
            int y;
            int max_x;
            int max_y;
            byte[] image;
            bool valid = true;

            for (zoom=0; zoom<7; zoom++)
            {
                max_x = m_tmData.GetNumTilesAcross(zoom);
                max_y = m_tmData.GetNumTilesDown(zoom);
                
                for(x=0; x<(max_x+1); x++)
                {
                    for (y = 0; y < (max_y + 1); y++)
                    {
                        image = null;
                        image = m_tmData.LoadTile(zoom, x, y);
                        if (image == null || image.Length == 0)
                        {
                            valid = false;
                        }
                        Console.WriteLine("x: "+x+" || y: "+y);
                     }
                }
            }

            return valid;
        }

        //delegate to point at VerifyTiles()
        public delegate bool VerifyTileDelg();
        public void VerifyTilesAsync()
        {
            VerifyTileDelg Delg;
            AsyncCallback callbackdelg;
            Delg = this.VerifyTiles;
            callbackdelg = this.CallbackFunc;
            ITMBizControllerCallback cb = OperationContext.Current.GetCallbackChannel<ITMBizControllerCallback>();
            Delg.BeginInvoke(callbackdelg, cb);
        }

        private void CallbackFunc(IAsyncResult result)
        {
            bool VerifyResult;
            VerifyTileDelg Delg;
            AsyncResult asyncobject = (AsyncResult)result;

            if(asyncobject.EndInvokeCalled == false)
            {
                Delg = (VerifyTileDelg)asyncobject.AsyncDelegate;
                VerifyResult = Delg.EndInvoke(asyncobject);
                if (VerifyResult)
                {
                    Console.WriteLine("Sucess");
                }
                else
                {
                    Console.WriteLine("fail");
                }
                ITMBizControllerCallback cb = (ITMBizControllerCallback)asyncobject.AsyncState;
                cb.OnVerificationComplete(VerifyResult);
            }
            asyncobject.AsyncWaitHandle.Close();
        }

        public void AddHisEntry(int x, int y, int zoom)
        {
            BH.BHAddHisEntry(x, y, zoom);            
        }

        public HistEntry HistBack()
        {
            His = BH.BHHistBack();

            return His;
        }

        public HistEntry HistForward()
        {
            His = BH.BHHistForward();

            return His;
        }

        public HistEntry GetCurrHistEntry()
        {
            His = BH.BHGetCurrHistEntry();
            return His;
        }

        public int GetCurrentIndex()
        {
            int CurrEntryIdx = BH.BHGetCurrentIndex();
            return CurrEntryIdx;
        }

        public int GetLastIndex()
        {
            int lastlistindex = BH.BHGetLastIndex();
            return lastlistindex;
        }

        public BrowseHistory GetFullHistory()
        {
            return BH;
        }

        public void SetFullHistory(BrowseHistory History)
        {
            BH = History;
        }
    }
}
