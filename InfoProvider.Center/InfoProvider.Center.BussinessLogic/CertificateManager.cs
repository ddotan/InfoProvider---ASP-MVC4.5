using InfoProvider.Center.ObjectModel;
using Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Center.BussinessLogic
{
    public class CertificateManager
    {
        public static CertificateRepository m_CertificateRepository = new CertificateRepository();
        private void updateCertificatesRepository()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<string> allCertificatePaths = new List<string>();
            LogManager.Instance.WriteInfo("Fetching & sorting certificates from " + m_CertificateRepository.r_CertificatePath + " ...");
            m_CertificateRepository.UpdateRepository();
            stopwatch.Stop();
            LogManager.Instance.WriteInfo("Fetching & sorting certificates , took: " + stopwatch.Elapsed);
        }
        public void UpdateCertificateProperty(List<Agent> i_Agents)
        {
            updateCertificatesRepository();
            foreach (Agent agent in i_Agents)
            {
                try
                {
                    agent.CertificatePath = m_CertificateRepository.GetCertificatePath(agent.RMSServer.Certificate);
                }
                catch (Exception ex)
                {
                    Logger.LogManager.Instance.WriteError("Error while trying to get certificate from: " + agent.RMSServer.ServerName + " Certificate name: " + agent.RMSServer.Certificate + " ,error: " + ex.Message);
                }
            }


        }
    }
}
