using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Master
{
    [ServiceContract(CallbackContract = typeof(IMasterControllerCallback))]

    //Inferface of the Airport Traffic Controller Master
    public interface IMasterController
    {
        [OperationContract]
        Airport initiateAirportSlave();

        [OperationContract]
        List<Airport> GetAllAirports();

        [OperationContract]
        List<Airport> incrementAllAirports();
    }
}
