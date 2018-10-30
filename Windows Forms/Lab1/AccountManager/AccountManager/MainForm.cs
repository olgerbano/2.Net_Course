using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EASendMail;

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
            AmountTextBox.Text = "";
            TransactionsListBox.Items.Clear();

            Transaction<double>[] transactions = _theAccount.AllTransactions;
            foreach (Transaction<double> trans in transactions)
            {
                string str = string.Format("{0}", trans);
                TransactionsListBox.Items.Add(str);
            }
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
            finally
            {
                AmountTextBox.Text = "";
                TransactionsListBox.Items.Clear();

                Transaction<double>[] transactions = _theAccount.AllTransactions;
                foreach (Transaction<double> trans in transactions)
                {
                    string str = string.Format("{0}", trans);
                    TransactionsListBox.Items.Add(str);
                }
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
            File.AppendAllText("LargeTransactions.txt", message+ Environment.NewLine);
            //File.AppendAllText("LargeTransactions.txt","\n");
            /*
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();
            oMail.From = "";
            oMail.To = "";
            
            oMail.Subject = "test email from yahoo account";
            oMail.TextBody = "this is a test email sent from c# project with yahoo.";
            
            SmtpServer oServer = new SmtpServer("smtp.mail.yahoo.com");
            
            oServer.User = "";
            oServer.Password = "";
            oServer.Port = 465;
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
            try
            {
               // Console.WriteLine("start to send email over SSL ...");
                oSmtp.SendMail(oServer, oMail);
                MessageBox.Show("email was sent successfully!");
            }
            catch (Exception ep)
            {
                MessageBox.Show("failed to send email with the following error:");
                MessageBox.Show(ep.Message);
            }
            */
        }

        private void OnLargeDebit(object sender, TransactionEventArgs e)
        {
            string message = string.Format("Large debit  at {0}: {1:c}\n", DateTime.Now, e.Amount);
            File.AppendAllText("LargeTransactions.txt", message+ Environment.NewLine);
            //File.AppendAllText("LargeTransactions.txt","\n");
        }

     
    }
}