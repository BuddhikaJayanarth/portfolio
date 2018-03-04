using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TrueMarbleBiz
{
    [ServiceContract(CallbackContract=typeof(ITMBizControllerCallback))]
    public interface TMBizController
    {
        [OperationContract]
        int GetTileWidth();
        [OperationContract]
        int GetTileHeight();
        [OperationContract]
        int GetNumTilesAcross(int zoom);
        [OperationContract]
        int GetNumTilesDown(int zoom);
        [OperationContract]
        byte[] LoadTile(int zoom, int x, int y);
        [OperationContract]
        bool VerifyTiles();
        [OperationContract]
        void VerifyTilesAsync();

        [OperationContract]
        void AddHisEntry(int x, int y, int zoom);

        [OperationContract]
        HistEntry HistBack();

        [OperationContract]
        HistEntry HistForward();

        [OperationContract]
        HistEntry GetCurrHistEntry();

        [OperationContract]
        int GetCurrentIndex();

        [OperationContract]
        int GetLastIndex();

        [OperationContract]
        BrowseHistory GetFullHistory();

        [OperationContract]
        void SetFullHistory(BrowseHistory History);
    }
}
