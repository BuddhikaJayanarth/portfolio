using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]

    //Implementation of functions defined in the interface
    internal class MasterControllerImpl:IMasterController
    {
        //initilising
        ATCDatabase.ATCDB dllDatabase = new ATCDatabase.ATCDB();

        //Number of Airports avalaible in the .dll database
        int numofAirports;

        //List of IDs for available airports
        int[] airportIDList;

        //Queue of all airports that a slave can yet claim
        Queue<Airport> availableAirportQueue = new Queue<Airport>();

        //List of all airport objects that were initiated by a slave
        List<Airport> MainAirportList = new List<Airport>();

        public MasterControllerImpl()
        {
            //initialising the values from the .dll database
            numofAirports = dllDatabase.GetNumAirports();
            airportIDList = dllDatabase.GetAirportIDList();

            //initialising appropiate objects for every entry in airportIDList
            foreach (int airportID in airportIDList)
            {

                //retrieve a list of airplanes for each airport ID
                int[] landedlist = dllDatabase.GetAirplaneIDsForAirport(airportID);

                Queue<Airplane> landedQueue = new Queue<Airplane>();

                //for each airplane in landed list create an airplane object
                foreach (int planeID in landedlist)
                {
                    string type;
                    double kmph;
                    double consume;
                    int currentAirportID;

                    //retrieving data from dll database into variables
                    dllDatabase.LoadAirplane(planeID, out type, out kmph, out consume, out currentAirportID);

                    //creating an storing airplane object in queue
                    landedQueue.Enqueue(new Airplane(planeID, type, kmph, consume, currentAirportID));
                }


                //retrieve a list of departure air routes for each airport ID
                int[] routelist = dllDatabase.GetDepartingAirRouteIDsForAirport(airportID);

                Queue<AirRoute> routeQueue = new Queue<AirRoute>();

                //for each air route in routelist create an AirRoute object
                foreach (int routeID in routelist)
                {
                    int fromID;
                    int toID;
                    double routeDistance;

                    //retrieving data from dll database into variables
                    dllDatabase.LoadAirRoute(routeID, out fromID, out toID, out routeDistance);

                    //creating an storing airplane object in queue
                    routeQueue.Enqueue(new AirRoute(routeID, fromID, toID, routeDistance));

                }

                //using above queues create and object for the airport
                string AirportName;
                dllDatabase.LoadAirport(airportID, out AirportName);
                availableAirportQueue.Enqueue(new Airport(airportID, AirportName, landedQueue, routeQueue));
                Console.WriteLine(airportID+ AirportName);
            }

            
        }

        public Airport initiateAirportSlave()
        {
            try
            {
                Airport tempAirport = availableAirportQueue.Dequeue();
                tempAirport.callbackChannel = OperationContext.Current.GetCallbackChannel<IMasterControllerCallback>();
                MainAirportList.Add(tempAirport);
                return tempAirport;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        List<Airport> portList2;
        public delegate Airport getslaveportDel();
        //returns a list of all slaves's airport objects
        public List<Airport> GetAllAirports()
        {
            try
            {

                Console.WriteLine("master1");
            //list to hold the airport objects
            portList2 = new List<Airport>();

            //queue holds all the getSlaveAirPort delegates
            Queue<getslaveportDel> functiondelQueue = new Queue<getslaveportDel>();
                Console.WriteLine("master2");
            //queue to hold the resultant objects
            Queue<IAsyncResult> resultQueue = new Queue<IAsyncResult>();
                Console.WriteLine("master3");
                // for every slave airport put the getSlaveAirPort function into a delgate and call it ansychronously
                foreach (Airport airportinput in MainAirportList)
            {
                getslaveportDel del = airportinput.callbackChannel.getSlaveAirPort;
                IAsyncResult res = del.BeginInvoke(null, null);
                functiondelQueue.Enqueue(del);
                resultQueue.Enqueue(res);
            }
                Console.WriteLine("master4");
                // for every invoked async function an endinvoke must be called
                foreach (getslaveportDel del in functiondelQueue)
            {
                IAsyncResult tempRes = resultQueue.Dequeue();
                portList2.Add(del.EndInvoke(tempRes));

                //the IAsyncResult taken out from resultQueue is need later so we will put it back in
                resultQueue.Enqueue(tempRes);
            }
                Console.WriteLine("master5");
                //close all wait handles
                foreach (IAsyncResult res in resultQueue)
            {
                res.AsyncWaitHandle.Close();
            }
                Console.WriteLine("master6");
                foreach(Airport port in portList2)
                {
                    Console.WriteLine(port.airportName);
                }
                //return the airport object list
                return portList2;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public delegate void incslaveportDel();
        //will call a asynchrounous callback function to increment each slave airport
        public List<Airport> incrementAllAirports()
        {
            try
            {
                Console.WriteLine("master1");

                //queue holds all the getSlaveAirPort delegates
                Queue<incslaveportDel> functiondelQueue1 = new Queue<incslaveportDel>();
                Console.WriteLine("master2");
                //queue to hold the resultant objects
                Queue<IAsyncResult> resultQueue1 = new Queue<IAsyncResult>();
                Console.WriteLine("master3");
                // for every slave airport put the incrementSlaveAirPort function into a delgate and call it ansychronously
                foreach (Airport airportinput in MainAirportList)
                {
                    incslaveportDel del1 = airportinput.callbackChannel.incrementSlaveAirport;
                    IAsyncResult res1 = del1.BeginInvoke(null, null);
                    functiondelQueue1.Enqueue(del1);
                    resultQueue1.Enqueue(res1);
                }
                Console.WriteLine("master4");
                //for every invoked async function an endinvoke must be called
                foreach (incslaveportDel del1 in functiondelQueue1)
                    {
                        IAsyncResult tempRes1 = resultQueue1.Dequeue();

                        //the IAsyncResult taken out from resultQueue is need later so we will put it back in
                        resultQueue1.Enqueue(tempRes1);
                    }
                Console.WriteLine("master5");
                //close all wait handles
                foreach (IAsyncResult res1 in resultQueue1)
                {
                    res1.AsyncWaitHandle.Close();
                }
                Console.WriteLine("master6");

                return GetAllAirports();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }

    }
}
