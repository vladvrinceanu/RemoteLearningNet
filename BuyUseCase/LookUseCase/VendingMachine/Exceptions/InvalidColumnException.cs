using System;

namespace iQuest.VendingMachine.Exceptions
{
    [Serializable()]

    internal class InvalidColumnException : Exception
    {
        public InvalidColumnException(string message)
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
