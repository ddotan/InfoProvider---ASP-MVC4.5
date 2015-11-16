using InfoProvider.Agent.ObjectModel.RMSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InfoProvider.Center.ObjectModel
{
    public class Agent
    {
        public RMSServer RMSServer { get; set; }
        public List<RMSBridge> RMSBridges { get; set; }
        public string CertificatePath { get; set; }
        public Agent()
        {
            RMSBridges = new List<RMSBridge>();
        }
    }
}
