using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Master
{
    class Program
    {
        static void Main(string[] args)
        {
            MasterControllerImpl MI = new MasterControllerImpl(); 
            ServiceHost host;
            NetTcpBinding tcpBinding = new NetTcpBinding();
            tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;
            tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;
            try
            {
                host = new ServiceHost(MI);
                host.AddServiceEndpoint(typeof(IMasterController), tcpBinding, "net.tcp://localhost:50000/Master");
                host.Open();
                System.Console.WriteLine("Service started at localhost:50000/Master");
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
