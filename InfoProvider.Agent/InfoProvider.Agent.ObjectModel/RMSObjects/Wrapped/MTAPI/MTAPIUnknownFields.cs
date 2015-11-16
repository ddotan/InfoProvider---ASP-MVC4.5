using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Agent.ObjectModel.RMSObjects
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.springframework.net")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.springframework.net", IsNullable = false)]
    public partial class objects
    {

        private objectsObject objectField;

        /// <remarks/>
        public objectsObject @object
        {
            get
            {
                return this.objectField;
            }
            set
            {
                this.objectField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.springframework.net")]
    public partial class objectsObject
    {

        private objectsObjectProperty[] propertyField;

        private string nameField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("property")]
        public objectsObjectProperty[] property
        {
            get
            {
                return this.propertyField;
            }
            set
            {
                this.propertyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.springframework.net")]
    public partial class objectsObjectProperty
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
