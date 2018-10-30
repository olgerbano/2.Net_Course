using System;
using System.Collections.Generic;

namespace PointOfSale
{
    // Really lame implementation, this should be a database
    public class Inventory
    {
        // This is the list of products
        List<Product> productList;

        public Inventory()
        {
            // Initialize the list of products
            productList = new List<Product>();
            productList.Add(new Product(1, "Chainring", 4.99M, 10));
            productList.Add(new Product(2, "Seat Tube", 8.99M, 5));
            productList.Add(new Product(3, "Seat", 29.99M, 5));
            productList.Add(new Product(4, "Stem", 14.99M, 5));
            productList.Add(new Product(5, "Inner Tube", 6.99M, 20));
            productList.Add(new Product(6, "Wheel", 19.99M, 10));
            productList.Add(new Product(7, "Brake Cable", 10.99M, 10));
            productList.Add(new Product(8, "Brake Block", 6.99M, 20));
            productList.Add(new Product(9, "Tire", 19.99M, 10));
            productList.Add(new Product(10, "Chain", 14.99M, 10));
        }

        // Give access to the list of products
        public List<Product> Products
        {
            get { return productList; }
        }

        // Remove some items from stock
        public decimal Buy(int ID, int quantity)
        {
            // Check that the specified item is in the inventory
            Predicate<Product> match = delegate(Product product)
            {
                return (product.ID == ID);
            };
            Product found = productList.Find(match);
            if (found == null) return 0M;
            // Remove the specified number of items and return the total cost.
            // Decrement will return the remaining items in stock if the full
            // order are not in stock.
            return (found.Decrement(quantity) * found.CostPerItem);
        }

        // Add some items to the stock refunding their cost.
        public decimal Refund(int ID, int quantity)
        {
            // Check that the specified item is in the inventory
            Predicate<Product> match = delegate(Product product)
            {
                return (product.ID == ID);
            };
            Product found = productList.Find(match);
            if (found == null) return 0M;
            // Add the items to the stock.
            found.Increment(quantity);
            // Return the money to be refunded.
            return quantity * found.CostPerItem;
        }

        // Query the inventory for an item by name.
        public Product Query(string name)
        {
            Predicate<Product> match = delegate(Product product)
            {
                return (product.Name == name);
            };
            return productList.Find(match);
        }
    }

    // This represents a product ite,
    public class Product
    {
        private int id;
        private string name;
        private decimal costPerItem;
        private int stockLevel;

        public int ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public decimal CostPerItem
        {
            get { return costPerItem; }
        }

        public int StockLevel
        {
            get { return stockLevel; }
        }

        public Product(int id, string name, decimal costPerItem, int stockLevel)
        {
            this.id = id;
            this.name = name;
            this.costPerItem = costPerItem;
            this.stockLevel = stockLevel;
        }

        // Increment the stock by the specified amount.
        public void Increment(int byHowMany)
        {
            stockLevel += byHowMany;
        }

        // Decrement the stock by the specified amount. The number of items
        // removed is returned. If there is less that the requested amount then
        // as many as possible are removed.
        public int Decrement(int byHowMany)
        {
            if (byHowMany > stockLevel) byHowMany = stockLevel;
            stockLevel -= byHowMany;
            return byHowMany;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
