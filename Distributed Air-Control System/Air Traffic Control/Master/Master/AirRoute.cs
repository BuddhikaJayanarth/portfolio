using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    [DataContract]
    public class AirRoute
    {

        // ID number of Air Route
        [DataMember]
        public int AirRouteID { get; set; }

        // origin airport of the route
        [DataMember]
        public int fromAirportID { get; set; }

        // destination airport of the route
        [DataMember]
        public int toAirportID { get; set; }

        // distance covered by route in km
        [DataMember]
        public double routeDistance { get; set; }

        public AirRoute(int RouteID, int fromID, int toID, double distance)
        {

            // initiliasing variables
            this.AirRouteID = RouteID;
            this.fromAirportID = fromID;
            this.toAirportID = toID;
            this.routeDistance = distance;
        }
    }
}
