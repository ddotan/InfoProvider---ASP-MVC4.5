using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Agent.ObjectModel.RMSObjects
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/Theseus.RiskManagement.Common")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Theseus.RiskManagement.Common", IsNullable = false)]
    public partial class SystemSettingsState
    {

        private string certificateSubjectNameField;

        private string handlerTypeField;
        //company name missing
        private ushort ServersPortField;

        private object passwordField;

        private string serverNameField;

        private ushort serverPortField;

        private object usernameField;

        private UsernamePassword[] usersField;

        /// <remarks/>
        public string CertificateSubjectName
        {
            get
            {
                return this.certificateSubjectNameField;
            }
            set
            {
                this.certificateSubjectNameField = value;
            }
        }

        /// <remarks/>
        public string HandlerType
        {
            get
            {
                return this.handlerTypeField;
            }
            set
            {
                this.handlerTypeField = value;
            }
        }

        /// <remarks/>
        /// //MissingCompanyName
        public ushort ServersPort
        {
            get
            {
                return this.ServersPortField;
            }
            set
            {
                this.ServersPortField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        /// <remarks/>
        public string ServerName
        {
            get
            {
                return this.serverNameField;
            }
            set
            {
                this.serverNameField = value;
            }
        }

        /// <remarks/>
        public ushort ServerPort
        {
            get
            {
                return this.serverPortField;
            }
            set
            {
                this.serverPortField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object Username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("UsernamePassword", Namespace = "http://schemas.datacontract.org/2004/07/Theseus.Common.Public.Authentication", IsNullable = false)]
        public UsernamePassword[] Users
        {
            get
            {
                return this.usersField;
            }
            set
            {
                this.usersField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/Theseus.Common.Public.Authentication")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Theseus.Common.Public.Authentication", IsNullable = false)]
    public partial class UsernamePassword
    {

        private string passwordField;

        private string usernameField;

        /// <remarks/>
        public string Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        /// <remarks/>
        public string Username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }
    }


}
