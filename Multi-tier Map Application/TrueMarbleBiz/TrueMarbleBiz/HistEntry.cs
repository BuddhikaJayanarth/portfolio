using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TrueMarbleBiz
{
    [DataContract]
    public class HistEntry
    {
        public HistEntry(int xi, int yi, int zoomi)
        {
            x = xi;
            y = yi;
            zoom = zoomi;
        }

        [DataMember]
        public int x { get; set; }

        [DataMember]
        public int y { get; set; }

        [DataMember]
        public int zoom { get; set; }
    }
}
