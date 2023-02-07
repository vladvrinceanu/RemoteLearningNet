using System;

namespace iQuest.VendingMachine.Exceptions
{
    [Serializable()]
    internal class InsuficientStockException : Exception
    {
        public InsuficientStockException(string message)
            : base(message)
        { }
        public override string StackTrace
        {
            get
            {
                return "";
            }
        }
    }
}
