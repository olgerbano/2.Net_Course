 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializareXML
{
    public class OrderedItem
    {
        string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        decimal unitPrice;

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        decimal lineTotal;

        public decimal LineTotal
        {
            get { return lineTotal; }
            set { lineTotal = value; }
        }

        /* Calculate is a custom method that calculates the price per item,
           and stores the value in a field. */
        public void Calculate()
        {
            lineTotal = unitPrice * quantity;
        }
    }
}
