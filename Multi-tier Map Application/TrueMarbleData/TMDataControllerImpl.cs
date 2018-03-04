using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.CompilerServices;

namespace TrueMarbleData
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class TMDataControllerImpl : ITMDataController
    {
        public TMDataControllerImpl() {
            Console.WriteLine("It started");
        }

        ~TMDataControllerImpl()
        {
            Console.WriteLine("It ended");
        }

        public int GetTileWidth()
        {
            int h;
            int w;
            TMDLLWrapper.GetTileSize(out w, out h);
            return w;
        }

        public int GetTileHeight()
        {
            int h;
            int w;
            TMDLLWrapper.GetTileSize(out w, out h);
            return h;
        }

        public int GetNumTilesAcross(int zoom)
        {
            int x;
            int y;
            TMDLLWrapper.GetNumTiles(zoom, out x, out y);
            return x;
        }

        public int GetNumTilesDown(int zoom)
        {
            int x;
            int y;
            TMDLLWrapper.GetNumTiles(zoom, out x, out y);
            return y;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public byte[] LoadTile(int zoom, int x, int y)
        {
            int h;
            int w;
            TMDLLWrapper.GetTileSize(out w, out h);
            byte[] imageBuf;
            int jpgSize;
            int buffsize = w * h * 3;
            imageBuf = new byte[buffsize];
            TMDLLWrapper.GetTileImageAsRawJPG(zoom, x, y, imageBuf, buffsize, out jpgSize);
            return imageBuf;

        }
    }
}
