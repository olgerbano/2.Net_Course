using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AccountManager
{
    public partial class MainForm : Form
    {
        // Account instance managed by the form.
        private Account _theAccount = new Account("John Doe");

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _theAccount.LargeCredit += OnLargeCredit;
            _theAccount.LargeDebit += OnLargeDebit;
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            double amount = double.Parse(AmountTextBox.Text);
            _theAccount.Deposit(amount);
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            double amount = double.Parse(AmountTextBox.Text);
            try
            {
                _theAccount.Withdraw(amount);
            }
            catch (TransactionException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            string details = _theAccount.ToString();
            MessageBox.Show(details, "Account details");

            TransactionsListBox.Items.Clear();

            Transaction<double>[] transactions = _theAccount.AllTransactions;
            foreach (Transaction<double> trans in transactions)
            {
                string str = string.Format("{0}", trans);
                TransactionsListBox.Items.Add(str);
            }
        }

        private void OnLargeCredit(object sender, TransactionEventArgs e)
        {
            string message = string.Format("Large credit at {0}: {1:c}\n", DateTime.Now, e.Amount);
            File.AppendAllText("LargeTransactions.txt", message);
        }

        private void OnLargeDebit(object sender, TransactionEventArgs e)
        {
            string message = string.Format("Large debit  at {0}: {1:c}\n", DateTime.Now, e.Amount);
            File.AppendAllText("LargeTransactions.txt", message);
        }
    }
}