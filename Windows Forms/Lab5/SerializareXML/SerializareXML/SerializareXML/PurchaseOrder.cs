using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializareXML
{
    /* The XmlRootAttribute allows you to set an alternate name 
   (PurchaseOrder) of the XML element, the element namespace; by 
   default, the XmlSerializer uses the class name. The attribute 
   also allows you to set the XML namespace for the element.  Lastly,
   the attribute sets the IsNullable property, which specifies whether 
   the xsi:null attribute appears if the class instance is set to 
   a null reference. */
    [XmlRootAttribute("PurchaseOrder", Namespace = "http://www.cpandl.com", IsNullable = false)]
    public class PurchaseOrder
    {
        private Address shipTo;

        public Address ShipTo
        {
            get { return shipTo; }
            set { shipTo = value; }
        }

        private string orderDate;

        public string OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        /* The XmlArrayAttribute changes the XML element name
         from the default of "OrderedItems" to "Items". */
        [XmlArrayAttribute("Items")]
        public OrderedItem[] orderedItems;

        public OrderedItem[] OrderedItems
        {
            get { return orderedItems; }
            set { orderedItems = value; }
        }

        private decimal subTotal;

        public decimal SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }
        private decimal shipCost;

        public decimal ShipCost
        {
            get { return shipCost; }
            set { shipCost = value; }
        }
        private decimal totalCost;

        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
    }
}
