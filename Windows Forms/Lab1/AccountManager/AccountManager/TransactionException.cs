using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AccountManager
{
    public class TransactionException : Exception,ISerializable
    {
        // Default constructor.
        public TransactionException()
        {
            // Implicitly invokes parameterless constructor in base class.
        }

        
        // Constructor that accepts a single string message.
        public TransactionException(string message)
            : base(message)
        {
        }

        /*
            // Constructor that accepts a string message and an inner exception 
            // that will be wrapped by the custom exception class.
            public TransactionException(string message, Exception inner)
                : base(message, inner)
            {
            }
            */
        public TransactionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
