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
    public partial class AccountForm : Form
    {
        // Account instance managed by the form.
        private Account _theAccount;

        public AccountForm(Account acc)
        {
            InitializeComponent();

            // Set the Account object for this form.
            _theAccount = acc;

            // Set the caption on the form.
            this.Text = string.Format("Account: {0}", _theAccount.Name);
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
            // Display account details in a message box.
            string details = _theAccount.ToString();
            MessageBox.Show(details, "Account details");

            // Declare variables to hold transaction lists.
            List<Transaction<double>> all, deposits, withdrawals;

            if (SortByDateRadioButton.Checked)
            {
                // Sort transactions by date.
                _theAccount.GetTransactionsByDate(out all, out deposits, out withdrawals);
            }
            else
            {
                // Sort transactions by amount.
                _theAccount.GetTransactionsByAmount(out all, out deposits, out withdrawals);
            }

            // Display transactions.
            AllTransactionsListBox.DataSource = all;
            DepositsListBox.DataSource = deposits;
            WithdrawalsListBox.DataSource = withdrawals;
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

        private void NotesButton_Click(object sender, EventArgs e)
        {
            // Display the notes for the Account object in the NotesForm form.
            NotesForm form = new NotesForm(_theAccount);
            form.ShowDialog();
        }
    }
}