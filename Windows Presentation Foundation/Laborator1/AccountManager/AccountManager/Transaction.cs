using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager
{
    // The Transaction structure represents a debit or credit transaction for a bank account.
    public struct Transaction<T> : IComparable<Transaction<T>> , IFormattable
        where T:IComparable
    {
        // Amount and timestamp instance variables.
        private T _amount;
        private DateTime _timestamp;

        // Constructor.
        public Transaction( T amt, DateTime ts)
        {
            _amount = amt;
            _timestamp = ts;
        }

        public int CompareTo(Transaction<T> other)
        {
            return _amount.CompareTo(other._amount); 
            throw new NotImplementedException();
        }

        /*
        public int CompareTo(object obj)
        {
            Transaction < T > aux = (Transaction<T>)obj;
                return this._amount.CompareTo(aux._amount));
            // throw new NotImplementedException();
        }
        */

        // Override the ToString method from System.Object.
        public override string ToString()
        {
            return string.Format("{0}, {1:c}", _timestamp.ToString(), _amount);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if(format == "d")
                return string.Format("{0}", _timestamp.ToString());
            else if(format == "a")
                return string.Format("{0:c}", _amount);
            return ToString();
           // throw new NotImplementedException();
        }
    }
}
