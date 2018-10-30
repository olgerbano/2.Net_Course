using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager
{
    class TransactionException : Exception
    {
        public TransactionException()
        {
        }

        public TransactionException(string message) : base(message)
        {
        }

        public TransactionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
