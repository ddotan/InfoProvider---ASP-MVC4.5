using InfoProvider.Agent.Contract;
using InfoProvider.Agent.ObjectModel;
using InfoProvider.Agent.ObjectModel.RMSObjects;
using InfoProvider.Agent.TechnicalServices;
using InfoProvider.Agent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Agent.Core
{
    public class InfoProviderService : IInfoProviderService
    {
        AppConfig m_Appconfig = AppConfigParser.Create<AppConfig>();
        public List<RMSBridge> GetBridgeAgents()
        {

            RMSAgentManger<RMSBridge> instanceManager = new RMSAgentManger<RMSBridge>();
            if (Boolean.Parse(m_Appconfig.SearchForBridge))
            {
                return instanceManager.GetRMSAgents();
            }
            else
            {
                throw new Exception("You can only request RMSBridge Configuration from this Server");

            }
        }

        public List<RMSServer> GetServerAgents()
        {
            RMSAgentManger<RMSServer> instanceManager = new RMSAgentManger<RMSServer>();
            if (Boolean.Parse(m_Appconfig.SearchForServer))
            {
                return instanceManager.GetRMSAgents();
            }
            else
            {
                throw new Exception("You can only request RMSServer Configuration from this Server");
            }
        }


    }
}
