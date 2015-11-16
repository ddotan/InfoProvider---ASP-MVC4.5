using InfoProvider.Agent.ObjectModel.RMSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
namespace InfoProvider.Agent.Contract

{
    [ServiceContract]
    public interface IInfoProviderService
    {
        [OperationContract]
        List<RMSBridge> GetBridgeAgents();
        [OperationContract]
        List<RMSServer> GetServerAgents();

    }
}
