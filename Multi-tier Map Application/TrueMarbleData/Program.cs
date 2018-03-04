using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrueMarbleData
{
    class Program
    {
        static void Main(string[] args)
        {
            TMDataControllerImpl DI = new TMDataControllerImpl();
            ServiceHost host;
            NetTcpBinding tcpBinding = new NetTcpBinding();
            tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;
            tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;
            try {
                host = new ServiceHost(DI);
                host.AddServiceEndpoint(typeof(ITMDataController), tcpBinding, "net.tcp://localhost:5001/TMData");
                host.Open();
                System.Console.WriteLine("Service started");
                Thread.Sleep(Timeout.Infinite);
                host.Close();
            }
            catch (FaultException fe)
            {
                System.Console.WriteLine(fe);
            }
        }
    }
}
