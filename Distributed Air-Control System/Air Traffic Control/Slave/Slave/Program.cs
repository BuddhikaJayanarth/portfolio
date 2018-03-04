using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Slave
{
    class Program
    {
        static void Main(string[] args)
        {

            SlaveController slaveserver = new SlaveController();
            System.Console.WriteLine("Slave Server started");
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
