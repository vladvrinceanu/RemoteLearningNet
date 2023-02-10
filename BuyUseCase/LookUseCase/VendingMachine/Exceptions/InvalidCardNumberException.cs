using System;

namespace iQuest.VendingMachine.Exceptions
{
    [Serializable()]
    internal class InvalidCardNumberException : Exception
    {
        public InvalidCardNumberException(string message)
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
