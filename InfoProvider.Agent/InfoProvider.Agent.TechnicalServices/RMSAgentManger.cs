using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using InfoProvider.Agent.ObjectModel;
using InfoProvider.Agent.ObjectModel.RMSObjects;
using InfoProvider.Agent.TechnicalServices;
using InfoProvider.Agent.Utilities;
namespace InfoProvider.Agent.TechnicalServices
{
    public class RMSAgentManger<T> where T : class
    {
        AgentsInformationManager m_ServiceInfoManager = new AgentsInformationManager();
        AppConfig m_APPConfig = AppConfigParser.Create<AppConfig>();
        private readonly string r_ServerConfigFileName = "";
        private readonly string r_BridgeConfigFileName = "";

        public List<T> GetRMSAgents()
        {
            List<T> agents = new List<T>();
            string ServerConfigFilePath = string.Empty;
            string BridgeConfigFilePath = string.Empty;
            RMSServer SystemSettingsState;
            System.Collections.Generic.List<AgentInformation> agentsInformation = new List<AgentInformation>();
            T agent;
            agentsInformation = m_ServiceInfoManager.GetOnlineAgents(m_APPConfig.ServiceName);
            LogManager.Instance.WriteInfo("[Serlizing objects process started.....]");
            foreach (AgentInformation agentInfo in agentsInformation)
            {
                try
                {
                    if (typeof(T) == typeof(RMSBridge))
                    {
                        //Fetching Certificate from SystemStateConfiguration file inorder to compare server & bridge certificates.
                        ServerConfigFilePath = agentInfo.RootFolder + r_ServerConfigFileName;
                        BridgeConfigFilePath = agentInfo.RootFolder + r_BridgeConfigFileName;
                        SystemSettingsState = RMSServer.Parse(XmlUtility.Serilize<SystemSettingsState>(ServerConfigFilePath), agentInfo.InstanceName) as RMSServer;
                        agent = RMSBridge.Parse(XmlUtility.Serilize<objects>(BridgeConfigFilePath), agentInfo.InstanceName, SystemSettingsState.Certificate) as T;
                        (agent as RMSBridge).Central = Central.Parse(SystemSettingsState.CentralPort);
                        agents.Add(agent);
                    }
                    else
                    {
                        BridgeConfigFilePath = agentInfo.RootFolder + r_ServerConfigFileName;
                        agent = RMSServer.Parse(XmlUtility.Serilize<SystemSettingsState>(BridgeConfigFilePath), agentInfo.InstanceName) as T;
                        (agent as RMSServer).Central = Central.Parse((agent as RMSServer).CentralPort);
                        agents.Add(agent);

                    }
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteError("Error Serilizing Instance Name: " + agentInfo.InstanceName + " FilePath: " + ServerConfigFilePath + BridgeConfigFilePath + "  Error: " + ex.Message);
                }
            }
            LogManager.Instance.WriteInfo("[Done Serlizing objects process .....]");
            LogManager.Instance.WriteInfo("Serilized " + agents.Count + " out of " + agentsInformation.Count + " objects]");
            return agents;

        }
    }
}
