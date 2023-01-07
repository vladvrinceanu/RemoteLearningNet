using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Exceptions
{
    [Serializable()]
    internal class InsuficientStockException : Exception
    {
        public InsuficientStockException(string message)
            : base(message)
        { }
    }
}
