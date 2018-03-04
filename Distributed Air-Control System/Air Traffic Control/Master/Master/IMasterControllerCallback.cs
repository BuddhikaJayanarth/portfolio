using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    [ServiceContract]

    //Inferface of the Airport Traffic Controller Master but for callbacks
    public interface IMasterControllerCallback
    {

        // callback for returning a slaves airport object
        [OperationContract]
        Airport getSlaveAirPort();

        // callback for incrementing 15 minutes for slaves
        [OperationContract]
        void incrementSlaveAirport();

    }
}
