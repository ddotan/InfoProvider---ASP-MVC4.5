using InfoProvider.Agent.Core;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Agent.Host
{

    public class Program : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public static void Main(string[] args)
        {
            if (System.Environment.UserInteractive)
            {
                string parameter = string.Concat(args);

                try
                {
                    ServiceHost serviceHost = new ServiceHost(typeof(InfoProviderService));

                    serviceHost.Open();
                    LogManager.Instance.WriteInfo("InfoProvider Server Starting...........");

                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteError(ex.Message);
                }
            }
            else
            {

                ServiceBase.Run(new Program());

            }

        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            try
            {
                serviceHost = new ServiceHost(typeof(InfoProviderService));
                serviceHost.Open();
                LogManager.Instance.WriteInfo("InfoProvider Server Started, started listening");


            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteError(ex.Message);
            }
        }

    }

}

