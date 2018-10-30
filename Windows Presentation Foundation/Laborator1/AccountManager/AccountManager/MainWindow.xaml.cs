using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        // Account instance managed by the form.
        private Account _theAccount = new Account("John Doe");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {

        }

        private void Withdraw_Button_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                double amount = double.Parse(AmountTextBox.Text);
                _theAccount.Withdraw(amount);

            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a positive number");
            }

            catch (TransactionException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                UpdateTransactionListBox();
            }

        }

        private void Deposit_Button_Click(object sender, RoutedEventArgs e)
        {
            double amount = double.Parse(AmountTextBox.Text);
            _theAccount.Deposit(amount);

            UpdateTransactionListBox();
        }

        private void Details_Button_Click(object sender, RoutedEventArgs e)
        {
            string details = _theAccount.ToString();
            MessageBox.Show(details, "Account details");

            UpdateTransactionListBox();
        }

        private void UpdateTransactionListBox()
        {
            TransactionsListBox.Items.Clear();

            Transaction<double>[] transactions = _theAccount.AllTransactions;
            foreach (Transaction<double> trans in transactions)
            {
                string str = string.Format("{0}", trans);
                TransactionsListBox.Items.Add(str);
            }
        }

#if false
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
#endif
    }
}
