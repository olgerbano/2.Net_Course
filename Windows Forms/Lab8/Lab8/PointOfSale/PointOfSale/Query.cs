using System;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using System.Security.Principal;

namespace PointOfSale
{
    // This form is used to query the inventory
    public partial class Query : Form
    {
        Inventory inventory;
        public Query(Inventory inventory)
        {
            InitializeComponent();
            this.inventory = inventory;
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            this.gbResults.Enabled = (this.txtProduct.Text.Length > 0);
        }

        // This is called to query the inventory
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Product product = inventory.Query(this.txtProduct.Text);
            if (product != null)
            {
                this.lblProduct.Text = product.Name;
                this.lblStock.Text = product.StockLevel.ToString();
                this.lblPrice.Text = string.Format("{0:C}", product.CostPerItem);
            }
        }

        private void Query_Activated(object sender, EventArgs e)
        {
            UpdateUser();
        }

        // This is used to display user information
        public void UpdateUser()
        {
            IPrincipal principal = Thread.CurrentPrincipal;
            
        }
    }
}
