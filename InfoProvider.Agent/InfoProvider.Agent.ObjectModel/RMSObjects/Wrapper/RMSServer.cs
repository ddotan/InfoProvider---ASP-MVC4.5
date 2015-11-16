using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Agent.ObjectModel.RMSObjects
{
    [Serializable]
    [DataContract]
    public class RMSServer 
    {
        public RMSServer()
        {
            Users = new List<User>();
        }
        public RMSServer(string i_InstanceName)
        {
            InstanceName = i_InstanceName;
            Users = new List<User>();
        }
        public static RMSServer Parse(SystemSettingsState i_UnkownSystemStateObj, string i_InstanceName)
        {   
            RMSServer instanceItem = new RMSServer(i_InstanceName);
            foreach (UsernamePassword userPass in i_UnkownSystemStateObj.Users)
            {
                instanceItem.Users.Add(new User(userPass.Username, userPass.Password));
            }
            instanceItem.ServerName = i_UnkownSystemStateObj.ServerName;
            instanceItem.ServerPort = i_UnkownSystemStateObj.ServerPort.ToString();
            instanceItem.Certificate = i_UnkownSystemStateObj.CertificateSubjectName;
            instanceItem.CentralPort =  i_UnkownSystemStateObj.ServersPort.ToString();
            return instanceItem;

        }


        [DataMember]
        public eCentral Central { get; set; }
        [DataMember]
        public string InstanceName { get; set; }
        [DataMember]
        public string ServerName { get; set; }
        [DataMember]
        public string ServerPort { get; set; }
        [DataMember]
        public string CentralPort { get; set; }
        [DataMember]
        public string Certificate { get; set; }
        [DataMember]
        public List<User> Users { get; set; }


    }
    [Serializable]
    [DataContract]
    public class User
    {
        public User(string i_Username, string i_Password)
        {
            Username = i_Username;
            Password = i_Password;
        }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }

    }

}
