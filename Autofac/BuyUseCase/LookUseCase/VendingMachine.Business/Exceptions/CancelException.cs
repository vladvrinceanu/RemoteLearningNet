using System;

namespace iQuest.VendingMachine.Exceptions
{
    [Serializable()]
    internal class CancelException : Exception
    {
        public CancelException(string message)
           : base(message)
        { }
    }
}
