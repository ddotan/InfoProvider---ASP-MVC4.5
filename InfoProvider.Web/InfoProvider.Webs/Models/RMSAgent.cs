using InfoProvider.Webs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoProvider.Webs.Models
{
    public class RMSAgent
    {

            public static RMSAgent Parse(RMSServer i_Server, RMSBridge i_Bridge, string i_CertificatePath)
            {
                RMSAgent agent = new RMSAgent();
                if (i_Server != null)
                {

                    agent.Central = Enum.GetName(typeof(eCentral), i_Server.Central);
                    agent.Broker = i_Server.ServerName;
                    agent.Certificate = i_Server.Certificate;
                    agent.Port = i_Server.ServerPort;
                    agent.CertificatePath = i_CertificatePath;
                    agent.Users = i_Server.Users;
                }
                if (i_Bridge != null)
                {
                    agent.Platform = i_Bridge.PlatformAddress;
                    agent.Securities = i_Bridge.Securities;
                    agent.Groups = i_Bridge.Groups;

                }
                return agent;
            }

            public string Central { get; set; }
            public string Broker { get; set; }
            public string Certificate { get; set; }
            public string Port { get; set; }
            public string Groups { get; set; }
            public string Platform { get; set; }
            public string Securities { get; set; }
            public string CertificatePath { get; set; }
            public List<User> Users { get; set; }
        
    }
}