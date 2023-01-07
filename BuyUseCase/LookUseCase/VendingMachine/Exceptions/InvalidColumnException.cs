using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Exceptions
{
    [Serializable()]

    internal class InvalidColumnException : Exception
    {
        public InvalidColumnException(string message)
            : base(message)
        { }
    }
}
