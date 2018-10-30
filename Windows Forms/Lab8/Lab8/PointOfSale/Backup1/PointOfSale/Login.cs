using System;
using System.Security.Principal;
using System.Windows.Forms;
using System.Threading;

namespace PointOfSale
{
    // This form is used to get logon credentials.
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public string Username
        {
            get { return this.txtUsername.Text; }
        }

        public string Password
        {
            get { return this.txtPassword.Text; }
        }

        // Return a principal object for this user
        public IPrincipal Principal
        {
           get 
           {
              return Thread.CurrentPrincipal;
           }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtPassword.Text = "";
            this.txtUsername.Text = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}