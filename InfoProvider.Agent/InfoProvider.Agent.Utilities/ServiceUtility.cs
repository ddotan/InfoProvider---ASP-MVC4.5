using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Agent.Utilities

{
    public class ServiceUtility
    {
        public static List<ServiceController> GetRunningServiceByName(string i_ServicePrefix)
        {
            List<ServiceController> resultServices = new List<ServiceController>();
            ServiceController[] allServices = ServiceController.GetServices();
  
            foreach (ServiceController service in allServices)
            {

                if (service.ServiceName.ToLower().Contains(i_ServicePrefix.ToLower()) && service.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    resultServices.Add(service);

                }
            }
            return resultServices;
        }
    }
}
