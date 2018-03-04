using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Master;

namespace Slave
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    class SlaveController:IMasterControllerCallback
    {

        // an instance of the masters controller interface
        IMasterController masterInter;

        //holds airport object allocated by Master
        Airport slaveAirport;

        public SlaveController()
        {

            //establishes connection to Master Server
            NetTcpBinding tcpBinding = new NetTcpBinding();
            tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;
            tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;

            ChannelFactory<IMasterController> MasterFactory;
            string surl = "net.tcp://localhost:50000/Master";

            MasterFactory = new DuplexChannelFactory<IMasterController>(this, tcpBinding, surl);

            //channel to Master set
            masterInter = MasterFactory.CreateChannel();

            //retrieving airport object for the slave
            slaveAirport = masterInter.initiateAirportSlave();

            Console.WriteLine(slaveAirport.airportName + " server started");
        }


        public Airport getSlaveAirPort()
        {
            return slaveAirport;
        }

        public void incrementSlaveAirport()
        {
            Queue<Airplane> tempPlaneQueue = new Queue<Airplane>();

            //increment 15 minutes for landedQueue
            if (slaveAirport.landedQueue.Peek() != null) {

                //increase on ground time
                foreach (Airplane airplane1 in slaveAirport.landedQueue)
                {
                Airplane tempairplane = slaveAirport.landedQueue.Dequeue();
                tempairplane.groundedTime = tempairplane.groundedTime + 15;
                tempPlaneQueue.Enqueue(tempairplane);
                }

                //check if airport has availabe depature routes to assign
                if(slaveAirport.departingRouteQueue.Peek() != null)
                {

                    AirRoute nextroute = slaveAirport.departingRouteQueue.Dequeue();

                    //assign a route, refill fuel and change state of next departing plane
                    Airplane departingPlane = tempPlaneQueue.Dequeue();
                    departingPlane.AirRouteID = nextroute.AirRouteID;
                    departingPlane.totaldistance = nextroute.routeDistance;
                    departingPlane.distanceleft = nextroute.routeDistance;
                    double timeforroute = (departingPlane.totaldistance / departingPlane.cruisingkmph);
                    departingPlane.fuel = 1.15 * (departingPlane.fuelConsPerHour*timeforroute);
                    departingPlane.planeState = "Transit";
                    departingPlane.groundedTime = 0;

                    //add to transit list
                    slaveAirport.transitList.Add(departingPlane);
                }
            }

            //check if transitList is empty
            if (slaveAirport.transitList.Count != 0)
            {
                int listcount = slaveAirport.transitList.Count;

                //update details for transit plane for changes happened in 15 minutes
                for(int x=0; x<listcount; x++)
                {
                    slaveAirport.transitList[0].flightTime = slaveAirport.transitList[0].flightTime + 15;
                    slaveAirport.transitList[0].kmSoFar = (slaveAirport.transitList[0].cruisingkmph) * (slaveAirport.transitList[0].flightTime / 60);
                    slaveAirport.transitList[0].distanceleft = slaveAirport.transitList[0].totaldistance - slaveAirport.transitList[0].kmSoFar;
                    slaveAirport.transitList[0].fuel = slaveAirport.transitList[0].fuel - (slaveAirport.transitList[0].fuelConsPerHour*(15/60));
                }

                //transfer nessesary flights to entering list of destination when distance left is within 300km

            }

            //check if enteringList is empty
            if (slaveAirport.enteringList.Count != 0)
            {
                int listcount = slaveAirport.enteringList.Count;

                //update details for transit plane for changes happened in 15 minutes
                for (int x = 0; x < listcount; x++)
                {
                    slaveAirport.enteringList[0].flightTime = slaveAirport.enteringList[0].flightTime + 15;
                    slaveAirport.enteringList[0].kmSoFar = (slaveAirport.enteringList[0].cruisingkmph) * (slaveAirport.enteringList[0].flightTime / 60);
                    slaveAirport.enteringList[0].distanceleft = slaveAirport.enteringList[0].totaldistance - slaveAirport.enteringList[0].kmSoFar;
                    slaveAirport.enteringList[0].fuel = slaveAirport.enteringList[0].fuel - (slaveAirport.enteringList[0].fuelConsPerHour * (15 / 60));
                }

                //transfer nessesary flights to circling list of destination when distance left is 0

            }

            //check if circlingList is empty
            if (slaveAirport.circlingList.Count != 0)
            {
                int listcount = slaveAirport.circlingList.Count;

                //update details for transit plane for changes happened in 15 minutes
                for (int x = 0; x < listcount; x++)
                {
                    slaveAirport.circlingList[0].flightTime = slaveAirport.circlingList[0].flightTime + 15;
                    slaveAirport.circlingList[0].fuel = slaveAirport.circlingList[0].fuel - (slaveAirport.circlingList[0].fuelConsPerHour * (15 / 60));
                }

                //transfer crashed flights to crashlist

                //transfer lowest fueled flight to landedlist of destination

            }

        }
    }
}
