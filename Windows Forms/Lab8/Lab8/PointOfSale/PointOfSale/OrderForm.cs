using System;
using System.Security;
using System.Windows.Forms;

namespace PointOfSale
{
    // This form allows an authenticated user sell an item and issue refunds
    public partial class OrderForm : Form
    {
        // An object that gives access to the inventory.
        Inventory inventory;

        public OrderForm(Inventory inventory)
        {
            this.inventory = inventory;
            InitializeComponent();
            // Add each item into the combo box.
            foreach (Product product in inventory.Products)
            {
                this.comboProduct.Items.Add(product);
            }
        }

        // Don't allow the form to be closed by the user.
        private void OrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }

        // This is called when items are added or removed from the listview
        private void lvOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvOrder.SelectedIndices.Count > 0)
            {
                // an item is selected
                ProductItem item = this.lvOrder.SelectedItems[0] as ProductItem;
                this.comboProduct.SelectedIndex = this.comboProduct.FindString(item.ProductName);
                this.udQuantity.Value = item.Quantity;

                this.btnRemove.Enabled = true;
            }
            else
            {
                // An item was removed
                this.btnRemove.Enabled = false;
            }
        }

        private void OrderButtons()
        {
            this.btnOrder.Enabled = (this.lvOrder.Items.Count > 0);
            this.btnRefund.Enabled = (this.lvOrder.Items.Count > 0);
            this.btnNew.Enabled = (this.lvOrder.Items.Count > 0);
        }

        // This is called when an item is added to the order.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = this.comboProduct.SelectedItem as Product;
            ProductItem item = new ProductItem(
                product.Name, product.ID, Convert.ToInt32(this.udQuantity.Value));
            this.lvOrder.Items.Add(item);
            this.btnAdd.Enabled = false;
            OrderButtons();
        }

        // This is called when an item is removed from the order
        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.lvOrder.Items.Remove(this.lvOrder.SelectedItems[0]);
            this.btnRemove.Enabled = false;
            OrderButtons();
        }

        // Tally the cost of the order
        private void btnOrder_Click(object sender, EventArgs e)
        {
            decimal total = 0M;
            foreach (ProductItem item in lvOrder.Items)
            {
                total += inventory.Buy(item.ID, item.Quantity);
            }

            MessageBox.Show(string.Format("Customer payment {0:C}", total));
            lvOrder.Items.Clear();
            OrderButtons();
        }

        // Tally the money to be refunded
        private void btnRefund_Click(object sender, EventArgs e)
        {
            decimal total = 0M;
            foreach (ProductItem item in lvOrder.Items)
            {
                total += inventory.Refund(item.ID, item.Quantity);
            }

            MessageBox.Show(string.Format("Pay customer {0:C}", total));
            lvOrder.Items.Clear();
            OrderButtons();
        }

        // Clear the form
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.lvOrder.Items.Clear();
            this.comboProduct.SelectedIndex = -1;
            this.udQuantity.Value = 0;
        }

        private void SelectedItem()
        {
            this.btnAdd.Enabled = (this.udQuantity.Value > 0) & (this.comboProduct.SelectedIndex != -1);
            this.btnRemove.Enabled = false;
            this.lvOrder.SelectedIndices.Clear();
        }

        // This is called when the user changes the item in the combo box
        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItem();
        }

        // This is called when the user changes the quantity
        private void udQuantity_ValueChanged(object sender, EventArgs e)
        {
            SelectedItem();
        }

        // This is an item in the order list view
        class ProductItem : ListViewItem
        {
            string product;
            int quantity;
            int id;

            public ProductItem(string product, int id, int quantity)
            {
                this.quantity = quantity;
                this.product = product;
                this.id = id;

                this.Text = product;
                this.SubItems.Add(quantity.ToString());
            }

            public string ProductName
            {
                get { return product; }
            }

            public int Quantity
            {
                get { return quantity; }
            }

            public int ID
            {
                get { return id; }
            }
        }
    }
}