using InfoProvider.Center.BussinessLogic;
using InfoProvider.Center.Contract;
using InfoProvider.Center.ObjectModel;
using Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InfoProvider.Center.Core
{
    public class InfoProviderCenter : IInfoProviderCenter
    {
        private AgentsManager m_AgentManagers = new AgentsManager();

        public List<Agent> GetAgents()
        {
            List<Agent> agents = new List<Agent>();
            try
            {
                agents = m_AgentManagers.GetAgents();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteError("Error while trying to get agents, error: " + ex.Message);
            }
            return agents;
        }
        public DateTime GetUpdateTime()
        {
            return m_AgentManagers.GetUpdateTime();
        }
        public string GetCertificatePath(string i_CertificateName)
        {
            return CertificateManager.m_CertificateRepository.GetCertificatePath(i_CertificateName);
        }

        public void UpdateRepository()
        {
            m_AgentManagers.UpdateRepository();
        }

        public void StartSampling()
        {
            m_AgentManagers.StartSampling();
        }

        public void StopSampling()
        {
            m_AgentManagers.StopSampling();
        }
    }
}
