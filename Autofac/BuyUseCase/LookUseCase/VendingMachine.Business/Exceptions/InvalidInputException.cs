﻿using System;

namespace iQuest.VendingMachine.Exceptions
{
    [Serializable()]
    internal class InvalidInputException : Exception
    {
        public InvalidInputException(string message)
           : base(message)
        { }
    }
}
