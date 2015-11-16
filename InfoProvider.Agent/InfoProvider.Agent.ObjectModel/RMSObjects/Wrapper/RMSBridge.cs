using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace InfoProvider.Agent.ObjectModel.RMSObjects
{

    [Serializable]
    [DataContract]
    public class RMSBridge
    {
        public RMSBridge(string i_InstanceName)
        {
            InstanceName = i_InstanceName;
        }
        public static RMSBridge Parse(objects i_UnknownAPIObject, string i_InstanceName, string i_CertificateName)
        {
            RMSBridge mtapi = new RMSBridge(i_InstanceName);

            mtapi.Certificate = i_CertificateName;
            foreach (objectsObjectProperty prop in i_UnknownAPIObject.@object.property)
            {
                if (prop.name == "DealerId")
                {
                    mtapi.DealerId = prop.value;
                }
                else if (prop.name == "Groups")
                {

                    mtapi.Groups = prop.value;

                }
                else if (prop.name == "Securities")
                {
                    mtapi.Securities = prop.value;

                }
                else if (prop.name == "ComputerName")
                {
                    mtapi.PlatformAddress = prop.value;

                }
                else if (prop.name == "Port")
                {
                    mtapi.PlatformPort = prop.value;

                }
            }
            return mtapi;
        }

        [DataMember]
        public string InstanceName { get; set; }
        [DataMember]
        public string DealerId { get; set; }
        [DataMember]
        public string Groups { get; set; }
        [DataMember]
        public string Securities { get; set; }
        [DataMember]
        public string PlatformAddress { get; set; }
        [DataMember]
        public string Certificate { get; set; }
        [DataMember]
        public string PlatformPort { get; set; }
        [DataMember]
        public eCentral Central { get; set; }
    }
}
