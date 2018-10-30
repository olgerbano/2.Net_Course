using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializareXML
{
    public class Address
    {
        /* The XmlAttribute instructs the XmlSerializer to serialize the Name
           field as an XML attribute instead of an XML element (the default
           behavior). */
        [XmlAttribute]
        public string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string line1;

        public string Line1
        {
            get { return line1; }
            set { line1 = value; }
        }

        /* Setting the IsNullable property to false instructs the 
           XmlSerializer that the XML attribute will not appear if 
           the City field is set to a null reference. */
        [XmlElementAttribute(IsNullable = false)]
        public string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        private string zip;

        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }
    }
}
