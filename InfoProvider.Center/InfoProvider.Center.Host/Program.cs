using InfoProvider.Center.Core;
using Logger;
using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Center.Host
{
    class Program : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public static void Main(string[] args)
        {
            if (System.Environment.UserInteractive)
            {
                string parameter = string.Concat(args);
                switch (parameter.ToLower())
                {
                    case "-install":
                        ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                        LogManager.Instance.WriteInfo("Service Installed.");

                        break;
                    case "-console":
                        try
                        {
                            runProgram();
                            while (true)
                            { }

                        }
                        catch (Exception ex)
                        {
                            LogManager.Instance.WriteError(ex.Message);
                        }
                        break;
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
                runProgram();



            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteError(ex.Message);
            }
        }
        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            InfoProviderCenter infoProviderCenter = new InfoProviderCenter();
            infoProviderCenter.StopSampling();

        }
        private static void runProgram()
        {
    
            ServiceHost serviceHost = new ServiceHost(typeof(InfoProviderCenter));
            serviceHost.Open();
            InfoProviderCenter infoProviderCenter = new InfoProviderCenter();
            infoProviderCenter.StartSampling();
            LogManager.Instance.WriteInfo("InfoProviderCenter Server Started...........");
        }

    }
}
