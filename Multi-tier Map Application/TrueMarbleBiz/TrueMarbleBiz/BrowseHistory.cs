using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TrueMarbleBiz
{
    [DataContract]
    public class BrowseHistory
    {
        public BrowseHistory()
        {
            History = new List<HistEntry>();
            CurrEntryIdx = -1;
        }

        [DataMember]
        public List<HistEntry> History { get; set; }       

        [DataMember]
        int CurrEntryIdx { get; set; }

        public void BHAddHisEntry(int x, int y, int zoom)
        {
            int lastlistindex;
            lastlistindex = History.Count -1;

            if (lastlistindex > CurrEntryIdx)
            {
                for (int i = CurrEntryIdx+1; i < lastlistindex+1; i++)
                {
                    Console.WriteLine(i+" "+lastlistindex);
                    History.RemoveAt(i);
                }
            }

            History.Add(new HistEntry(x, y, zoom));

            CurrEntryIdx++;
        }

        public HistEntry BHHistBack()
        {
            CurrEntryIdx--;

            return History[CurrEntryIdx];
        }

        public HistEntry BHHistForward()
        {
            CurrEntryIdx++;

            return History[CurrEntryIdx];
        }

        public HistEntry BHGetCurrHistEntry()
        {
            return History[CurrEntryIdx];
        }

        public int BHGetCurrentIndex()
        {
            return CurrEntryIdx;
        }

        public int BHGetLastIndex()
        {
            int lastlistindex;
            lastlistindex = History.Count - 1;
            return lastlistindex;
        }
    }
}
