using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Exceptions
{
    [Serializable()]
    internal class CancelException : Exception
    {
        public CancelException(string message)
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
