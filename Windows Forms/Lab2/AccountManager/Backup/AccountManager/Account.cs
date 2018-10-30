using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.Specialized;

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

        // Notes for the account.
        private NameValueCollection _notes = new NameValueCollection();

        // Events.
        public event EventHandler<TransactionEventArgs> LargeCredit;
        public event EventHandler<TransactionEventArgs> LargeDebit;

        // Constructor.
        public Account(string name)
        {
            _name = name;
            _balance = 0;
            _mostRecentTransaction = null;

            // Add keys to the _notes collection.
            _notes.Add("Telephone notes", null);
            _notes.Add("E-mail notes", null);
            _notes.Add("Letter notes", null);
        }

        // Get the notes for the account.
        public NameValueCollection Notes
        {
            get { return _notes; }
        }

        // Get the name of the account holder.
        public string Name
        {
            get { return _name; }
        }

        // Deposit money into the account.
        public void Deposit(double amount)
        {
            _balance += amount;

            Transaction<double> trans = new Transaction<double>(amount, DateTime.Now);
            _mostRecentTransaction = trans;
            _allTransactions.Add(trans);

            if (amount >= 1000)
            {
                EventHandler<TransactionEventArgs> handler = LargeCredit;
                if (handler != null)
                {
                    TransactionEventArgs args = new TransactionEventArgs(amount);
                    handler(this, args);
                }
            }
        }

        // Withdraw money from the account.
        public void Withdraw(double amount)
        {
            if (_balance < 0)
            {
                string message = string.Format("Cannot withdraw {0:c} from overdrawn account for {1}.", amount, _name);
                throw new TransactionException(message);
            }

            _balance -= amount;

            Transaction<double> trans = new Transaction<double>(-amount, DateTime.Now);
            _mostRecentTransaction = trans;
            _allTransactions.Add(trans);

            if (amount >= 1000)
            {
                EventHandler<TransactionEventArgs> handler = LargeDebit;
                if (handler != null)
                {
                    TransactionEventArgs args = new TransactionEventArgs(amount);
                    handler(this, args);
                }
            }
        }

        // Return a string representation of an account.
        public override string ToString()
        {
            if (_mostRecentTransaction.HasValue)
            {
                return string.Format("{0}, {1:c}, most recent transaction: {2}",
                                      _name,
                                      _balance,
                                      _mostRecentTransaction.Value);
            }
            else
            {
                return string.Format("{0}, {1:c}, no recent transaction.",
                                      _name,
                                      _balance);
            }
        }

        // Get all transactions.
        public Transaction<double>[] AllTransactions
        {
            get
            {
                Transaction<double>[] copy = _allTransactions.ToArray();
                Array.Sort(copy);
                return copy;
            }
        }

        // Get all transactions, deposits, and withdrawals sorted by date.
        public void GetTransactionsByDate(out List<Transaction<double>> all,
                                          out List<Transaction<double>> deposits,
                                          out List<Transaction<double>> withdrawals)
        {
            // Create a copy of the transaction list.
            all = new List<Transaction<double>>(_allTransactions);
            
            // Sort the transactions by date.
            all.Sort(new TransactionDateComparer());
            
            // Find transactions that are deposits.
            deposits = all.FindAll(IsDeposit);
            
            // Find transactions that are withdrawals.
            withdrawals = all.FindAll(IsWithdrawal);
        }

        // Get all transactions, deposits, and withdrawals sorted by amount.
        public void GetTransactionsByAmount(out List<Transaction<double>> all,
                                            out List<Transaction<double>> deposits,
                                            out List<Transaction<double>> withdrawals)
        {
            // Create a copy of the transaction list.
            all = new List<Transaction<double>>(_allTransactions);

            // Sort the transactions by amount.
            all.Sort(new TransactionAmountComparer());

            // Find transactions that are deposits.
            deposits = all.FindAll(IsDeposit);

            // Find transactions that are withdrawals.
            withdrawals = all.FindAll(IsWithdrawal);
        }

        // Method that is used by a Predicate to determine if a transaction is a deposit.
        private bool IsDeposit(Transaction<double> trans)
        {
            return trans.Amount >= 0;
        }

        // Method that is used by a Predicate to determine if a transaction is a withdrawal.
        private bool IsWithdrawal(Transaction<double> trans)
        {
            return trans.Amount < 0;
        }
    }
}
