using InfoProvider.Webs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Logger;
using System.Threading;

namespace InfoProvider.Webs.Models
{
    public  class RMSAgentManager
    {

        private static RMSAgentManager m_Instance;
        private RMSAgentManager()
        {
            UpdateTime = m_Center.GetUpdateTime().ToString();
            MtCertPath = "";
        }
        public static RMSAgentManager Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new RMSAgentManager();
                }
                return m_Instance;
            }
        }
        public void StartKeepAliveInterval()
        {
            new Thread(() =>
           {
               while (true)
               {
                   m_Center.GetUpdateTime();
                   Thread.Sleep(TimeSpan.FromMinutes(3));
               }
           }).Start();
        }
        private  IInfoProviderCenter m_Center = new InfoProviderCenterClient();
        private List<RMSAgent> ConvertToAgents(List<Agent> i_Agents)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<RMSAgent> rmsAgents = new List<RMSAgent>();
            foreach (Agent agent in i_Agents)
            {
                if (agent.RMSBridges.Count > 0)
                {
                    foreach (RMSBridge bridge in agent.RMSBridges)
                    {
                        rmsAgents.Add(RMSAgent.Parse(agent.RMSServer, bridge, agent.CertificatePath));
                    }
                }
                else
                {
                    rmsAgents.Add(RMSAgent.Parse(agent.RMSServer, null, agent.CertificatePath));
                }

            }
            sw.Stop();
            //adds editional \ because visual studio cut one \.
            foreach (RMSAgent rms in rmsAgents)
            {
                rms.CertificatePath = rms.CertificatePath.Replace("\\", "\\\\");
            }
            return rmsAgents;
        }
        public List<RMSAgent> GetAgents()
        {
            List<RMSAgent> rmsAgents = new List<RMSAgent>();
            List<Agent> agents;
            try
            {
                agents = m_Center.GetAgents();
                rmsAgents = ConvertToAgents(agents);
                UpdateTime = m_Center.GetUpdateTime().ToString();
                MtCertPath = m_Center.GetCertificatePath("mainCert.com").Replace("\\", "\\\\");

            }
            catch
                (Exception ex)
            {
                LogManager.Instance.WriteError(ex.Message);
            }
            return rmsAgents;
        }
        public string MtCertPath { get; set; }
        public string UpdateTime { get; set; }

    }
}