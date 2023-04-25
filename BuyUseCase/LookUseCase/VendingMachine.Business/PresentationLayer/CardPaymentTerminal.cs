using iQuest.VendingMachine.Exceptions;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase, ICardPaymentTerminal
    {
        public string AskForCardNumber()
        {
            Console.WriteLine();
            Display("Please enter the card number: ", ConsoleColor.Cyan);
            string cardNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrWhiteSpace(cardNumber))
            {
                throw new CancelException("Canceled transaction.");
            }
            return cardNumber;
        }
        public void ApprovedCardMessage()
        {
            Console.WriteLine();
            DisplayLine("Valid Card.Transaction approved.", ConsoleColor.Green);
        }
        public void DisplayChosenPaymentMethod()
        {
            DisplayLine("Payment method: Card", ConsoleColor.White);
        }
        public void DisplayPrice(float price)
        {
            Console.WriteLine();
            DisplayLine($"Price: {price}", ConsoleColor.White);
        }
    }
}
