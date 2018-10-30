using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager
{
    // IComparer implementation that compares Transaction<double> objects by date.
    public class TransactionDateComparer : IComparer<Transaction<double>>
    {
        public int Compare(Transaction<double> x, Transaction<double> y)
        {
            // Compare the timestamps of the two objects.
            return x.TimeStamp.CompareTo(y.TimeStamp);
        }
    }

    // IComparer implementation that compares Transaction<double> objects by amount.
    public class TransactionAmountComparer : IComparer<Transaction<double>>
    {
        public int Compare(Transaction<double> x, Transaction<double> y)
        {
            // Compare the amounts of the two objects.
            return x.Amount.CompareTo(y.Amount);
        }
    }
}
