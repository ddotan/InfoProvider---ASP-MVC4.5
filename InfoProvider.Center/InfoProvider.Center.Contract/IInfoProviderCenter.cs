using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using InfoProvider.Center.ObjectModel;
namespace InfoProvider.Center.Contract
{
    [ServiceContract]
    public interface IInfoProviderCenter
    {
        [OperationContract]
        List<Agent> GetAgents();
        [OperationContract]
        DateTime GetUpdateTime();

        [OperationContract]
        void UpdateRepository();
        [OperationContract]
        string GetCertificatePath(string i_CertificateName);

    }
}
