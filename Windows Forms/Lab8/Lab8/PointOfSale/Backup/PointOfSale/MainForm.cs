using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;

namespace PointOfSale
{
    public partial class MainForm : Form
    {
        OrderForm orderForm = null;
        Query queryForm = null;
        Inventory inventory;

        public MainForm()
        {
            InitializeComponent();
            inventory = new Inventory();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If already logged in then log out
            logoutToolStripMenuItem_Click(sender, e);

            Login dlg = new Login();
            dlg.StartPosition = FormStartPosition.CenterParent;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                IPrincipal principal = dlg.Principal;
                Thread.CurrentPrincipal = principal;

                if (!principal.Identity.IsAuthenticated)
                {
                    MessageBox.Show("User is not authenticated", "Warning");
                }

                if (queryForm != null)
                {
                    queryForm.UpdateUser();
                }

                if (orderForm == null)
                {
                    orderForm = new OrderForm(inventory);
                    orderForm.MdiParent = this;
                }

                orderForm.Text = Thread.CurrentPrincipal.Identity.Name;
                orderForm.Show();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (orderForm != null)
            {
                orderForm.Visible = false;
            }
            if (queryForm != null)
            {
                queryForm.UpdateUser();
            }
        }

        private void queryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (queryForm == null)
            {
                queryForm = new Query(inventory);
                queryForm.MdiParent = this;
            }
            queryForm.Show();
        }
    }
}