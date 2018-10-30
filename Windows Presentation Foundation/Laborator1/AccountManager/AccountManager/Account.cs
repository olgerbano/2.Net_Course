using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountManager
{
    // The Account class represents a bank account.
    public class Account
    {
        // Name and balance of the bank account.
        private string _name;
        private double _balance;

        // Transaction information.
        private Transaction<double>? _mostRecentTransaction;
        private List<Transaction<double>> _allTransactions = new List<Transaction<double>>();

        // Constructor.
        public Account(string name)
        {
            _mostRecentTransaction = null;
            _name = name;
            _balance = 0;
            //_mostRecentTransaction = new Transaction(0, DateTime.MinValue);
        }

        // Deposit money into the account.
        public void Deposit(double amount)
        {
            _balance += amount;

            Transaction<double> trans = new Transaction<double>(amount, DateTime.Now);
            _mostRecentTransaction = trans;
            _allTransactions.Add(trans);
        }

        // Withdraw money from the account.
        public void Withdraw(double amount)
        {
            if(_balance < 0)
            {
                throw new TransactionException(string.Format("Cannot withdraw {0:c} from overdrawn account for {1}.", amount, _name));
            }
            if (amount < _balance)
            {
                _balance -= amount;

                Transaction<double> trans = new Transaction<double>(-amount, DateTime.Now);
                _mostRecentTransaction = trans;
                _allTransactions.Add(trans);
            }
            if(_balance == 0)
            {
                throw new TransactionException(string.Format("You have " + _balance + " please deposit money"));
                //MessageBox.Show("You have " + _balance + " please deposit money ");
            }
            else
            {
                throw new TransactionException(string.Format("You have " + _balance + " please withdrow an amount which is less than your current amount"));
                //MessageBox.Show("You have "+_balance+" please withdrow an amount which is less than your current amount");
            }
        }

        // Return a string representation of an account.
        public override string ToString()
        {
            if (_mostRecentTransaction.HasValue)
            {
                return string.Format("{0}, balance: {1:c}, most recent transaction: {2}",
                                      _name,
                                      _balance,
                                      _mostRecentTransaction);
            }
            else
            {
                string mes = "nicio tranzactie recenta";
                return string.Format("{0}, balance: {1:c}", mes, _name,
                                      _balance);
            }
        }

        // Get all transactions.
        public Transaction<double>[] AllTransactions
        {
            get
            {
                _allTransactions.Sort();
                Transaction<double>[] copy = _allTransactions.ToArray();
                return copy;
            }
        }
    }
}
