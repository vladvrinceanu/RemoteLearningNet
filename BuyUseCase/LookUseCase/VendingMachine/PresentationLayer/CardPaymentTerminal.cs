using iQuest.VendingMachine.Exceptions;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase
    {
        public string AskForCardNumber()
        {
            Display("Please enter the card number: ", ConsoleColor.Cyan);
            string cardNumber = Console.ReadLine();
            if (!string.IsNullOrEmpty(cardNumber) && !string.IsNullOrWhiteSpace(cardNumber))
            {
                return cardNumber;
            }
            else
            {
                throw new InvalidInputException("Invalid input.");
            }
        }  
    }
}
