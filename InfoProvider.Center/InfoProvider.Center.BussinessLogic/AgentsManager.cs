using InfoProvider.Agent.ObjectModel.RMSObjects;
using Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace InfoProvider.Center.BussinessLogic
{
    public class AgentsManager 
    {
        private static DateTime m_RequestTime;
        private static Thread m_updateRepositoryThread;
        private static RMSBridgeReference1.IInfoProviderService m_BridgeAPI;
        private static RMSServerReference1.IInfoProviderService m_ServerAPI;
        private static CertificateManager m_CertificateManager = new CertificateManager();
        private static List<Agent> m_Agents = new List<Agent>();
        private readonly int m_SampleInterval;
        public AgentsManager()
        {
            m_BridgeAPI = new RMSBridgeReference1.InfoProviderServiceClient();
            m_ServerAPI = new LRMSServerReference1.InfoProviderServiceClient();
            m_SampleInterval = int.Parse(ConfigurationManager.AppSettings["AgentsManager.SampleIntervalInMinutes"]);
        }

        public void UpdateRepository()
        {
            List<RMSBridge> bridges;
            List<RMSServer> servers;
            bridges = m_BridgeAPI.GetBridgeAgents();
            servers = m_ServerAPI.GetServerAgents();
            LogManager.Instance.WriteInfo("Found: " + "[Servers: " + servers.Count + "] [Bridges: " + bridges.Count + "]");
            List<InfoProvider.Center.ObjectModel.Agent> newAgentList = new List<InfoProvider.Center.ObjectModel.Agent>();
            MatchServersWithBridges(bridges, servers, ref newAgentList);
            m_CertificateManager.UpdateCertificateProperty(newAgentList);
            m_Agents = newAgentList;
            m_RequestTime = DateTime.Now;
        }
        public void StopSampling()
        {
            m_updateRepositoryThread.Abort();
        }
        public void StartSampling()
        {
            m_updateRepositoryThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        LogManager.Instance.WriteInfo("[Thread]Getting info from InfoProvider Agents...");
                        UpdateRepository();
                    }
                    catch (Exception ex)
                    {
                        LogManager.Instance.WriteError("Error while trying to request info from providers , error: " + ex.Message);
                    }


                    LogManager.Instance.WriteInfo("Found: " + m_Agents.Count + " Agents");
                    LogManager.Instance.WriteInfo("Request info from providers Done");
                    m_RequestTime = DateTime.Now;
                    Thread.Sleep(m_SampleInterval * 1000 * 60);
                }
            });
            m_updateRepositoryThread.Start();
        }
        public List<Agent> GetAgents()
        {
            return m_Agents;
        }
        public DateTime GetUpdateTime()
        {
            return m_RequestTime;
        }
        private void MatchServersWithBridges(List<RMSBridge> i_Bridges, List<RMSServer> i_Servers, ref List<Agent> i_NewAgentList)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool foundMatch = false;
            int withoutMatch = 0;
            foreach (RMSServer server in i_Servers)
            {
                foundMatch = false;

                foreach (RMSBridge bridge in i_Bridges)
                {
                    if (server.Central == bridge.Central && server.Certificate == bridge.Certificate)
                    {
                        Agent agent = new Agent();
                        agent.RMSBridges.Add(bridge);
                        agent.RMSServer = server;
                        i_NewAgentList.Add(agent);
                        foundMatch = true;

                    }
                }
                if (!foundMatch)
                {
                    i_NewAgentList.Add(new Agent() { RMSServer = server });
                    withoutMatch++;
                }


            }
            sw.Stop();
            LogManager.Instance.WriteInfo("Found matching bridge for: " + (i_Servers.Count - withoutMatch).ToString() + "/" + i_Servers.Count + " servers.");

        }

    }
}
