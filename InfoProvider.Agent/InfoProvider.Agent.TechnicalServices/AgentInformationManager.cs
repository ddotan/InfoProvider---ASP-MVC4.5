using InfoProvider.Agent.ObjectModel;
using InfoProvider.Agent.Utilities;
using Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Agent.TechnicalServices
{
    public class AgentsInformationManager
    {
        public List<AgentInformation> GetOnlineAgents(string i_ServiceName)
        {
            List<AgentInformation> serviceInfoResults = new List<AgentInformation>();
            string instance, folderPath;
            string[] pathParts={};
            instance = folderPath = string.Empty;
            List<InfoProvider.Agent.Utilities.ServiceController> allProccess = ServiceUtility.GetRunningServiceByName(i_ServiceName);
            foreach (InfoProvider.Agent.Utilities.ServiceController service in allProccess)
            {
                try
                {

                    pathParts = service.ImagePath.Split(new string[] { "-config" }, StringSplitOptions.None);
                    if (pathParts.Length == 2)
                    {

                        instance = pathParts[1].Trim();
                        folderPath = Directory.GetParent(pathParts[0].Trim().Replace("\"", "")).ToString() + "\\" + instance;
                        serviceInfoResults.Add(new AgentInformation() { InstanceName = instance, RootFolder = folderPath });

                    }
                    else
                    {
                        throw new Exception("Couldnt retrive service information, Service filepath count is more then 2");
                    }
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteError(" " + service.ServiceName + " Path:[" + ArrayHelper.ArrayToString(pathParts) + "] ,  exception: " + ex.Message);

                }
            }

            LogManager.Instance.WriteInfo("Found " + serviceInfoResults.Count + " Services that match [" + i_ServiceName + "]");
            return serviceInfoResults;
        }
    }
}
