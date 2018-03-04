using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    [DataContract]
    public class Airport
    {

        // ID number of airport
        [DataMember]
        public int airportID { get; set; }

        // Name of airport
        [DataMember]
        public string airportName { get; set; }

        //planes landed
        [DataMember]
        public Queue<Airplane> landedQueue { get; set; }

        //planes circling
        [DataMember]
        public List<Airplane> circlingList { get; set; }

        //planes entering-circling
        [DataMember]
        public List<Airplane> enteringList { get; set; }

        //planes in transit
        [DataMember]
        public List<Airplane> transitList { get; set; }


        //planes crashed
        [DataMember]
        public List<Airplane> crashList { get; set; }

        //queue for departing routes
        [DataMember]
        public Queue<AirRoute> departingRouteQueue { get; set; }

        // Callback channel to be used for this specific instance of the airport slave
        public IMasterControllerCallback callbackChannel { get; set; }

        public Airport(int ID, string name, Queue<Airplane> landed, Queue<AirRoute> departing)
        {

            //initialising variables
            this.airportID = ID;
            this.airportName = name;
            this.landedQueue = landed;
            this.circlingList = new List<Airplane>();
            this.enteringList = new List<Airplane>();
            this.departingRouteQueue = departing;
            this.callbackChannel = null;
        }
    }
}
