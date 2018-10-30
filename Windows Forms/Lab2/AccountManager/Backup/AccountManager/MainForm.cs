using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountManager
{
    public partial class MainForm : Form
    {
        // Dictionary of accounts.
        private Dictionary<int, Account> _accounts = new Dictionary<int,Account>();
        
        // Integer that provides the next account number.
        private int _nextAccountNumber = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            // Create an Account object with the specified name.
            Account acc = new Account(NameTextBox.Text);
            
            // Add the Account object to the dictionary.
            _accounts.Add(_nextAccountNumber, acc);
            
            // Increment the account number, ready for the next account.
            _nextAccountNumber++;

            // Redisplay all accounts.
            DisplayAccounts();
            NameTextBox.Clear();
            NameTextBox.Focus();
        }

        private void DisplayAccounts()
        {
            // Clear the DataGridView.
            AccountsDataGridView.Rows.Clear();

            // Iterate through the Account objects in the dictionary.
            foreach (KeyValuePair<int, Account> entry in _accounts)
            {
                // Add a (key, value) row to the DataGridView.
                AccountsDataGridView.Rows.Add(entry.Key, entry.Value);
            }
        }

        private void AccountsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the account number of the selected row in the DataGridView.
            int accNum = (int)AccountsDataGridView.SelectedRows[0].Cells["AccountNumber"].Value;

            // Lookup the Account object in the dictionary.
            Account theAccount = _accounts[accNum];

            // Display the Account object in the AccountForm form.
            AccountForm form = new AccountForm(theAccount);
            form.ShowDialog();

            // Redisplay all accounts.
            DisplayAccounts();
        }
    }
}