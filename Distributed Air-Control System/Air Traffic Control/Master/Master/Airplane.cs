using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    [DataContract]
    public class Airplane
    {
        // ID number of airplane
        [DataMember]
        public int airplaneID { get; set; }

        // Model type of airplane
        [DataMember]
        public string airplaneType { get; set; }

        // Average flying speed of airplane in km/h
        [DataMember]
        public double cruisingkmph { get; set; }

        // Amount of fuel used per hour during flight
        [DataMember]
        public double fuelConsPerHour { get; set; }

        // Airport ID that the plane is currently at (-1 during transit)
        [DataMember]
        public int currentAirportID { get; set; }

        // Assigned air route (-1 if no assigned route)
        [DataMember]
        public int AirRouteID { get; set; }

        // Distance travelled so far in km (0 if landed or just taken off)
        [DataMember]
        public double kmSoFar { get; set; }

        // Time spent after landed
        [DataMember]
        public double groundedTime { get; set; }

        //Airplane state: Landed, Transit, Entering, Circling, Crashed
        [DataMember]
        public string planeState { get; set; }

        //Remaining fuel
        [DataMember]
        public double fuel { get; set; }

        //total distance of current route
        public double totaldistance { get; set; }

        //distance left on current route (-1 if no assigned route)
        public double distanceleft { get; set; }

        //flight time
        public double flightTime { get; set; }



        public Airplane(int planeID, string type, double kmph, double consume, int currentAirport)
        {
            // initialising variables
            this.airplaneID = planeID;
            this.airplaneType = type;
            this.cruisingkmph = kmph;
            this.fuelConsPerHour = consume;
            this.currentAirportID = currentAirport;
            this.AirRouteID = -1;
            this.kmSoFar = 0;
            this.groundedTime = 0;
            this.fuel = 0;
            this.planeState = "Landed";
            this.totaldistance = 0;
            this.distanceleft = -1;
            this.flightTime = 0;
        }
    }
}
