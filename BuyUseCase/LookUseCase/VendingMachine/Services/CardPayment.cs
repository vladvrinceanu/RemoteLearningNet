using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.Services
{
    internal class CardPayment : DisplayBase, IPaymentAlgorithm
    {
        public string Name { get; set; }
        private CardPaymentTerminal cardPaymentTerminal;
        private CardValidator cardValidator;
        public CardPayment(string name, CardPaymentTerminal cardPaymentTerminal, CardValidator cardValidator)
        {
            Name = name;
            this.cardPaymentTerminal = cardPaymentTerminal;
            this.cardValidator = cardValidator;
        }
        public void Run(float price)
        {
            Console.WriteLine();
            DisplayLine("Payment method: Card", ConsoleColor.White);
            DisplayLine($"Price: {price}", ConsoleColor.White);
            string cardNumber = cardPaymentTerminal.AskForCardNumber();

            if (cardValidator.IsCardNumberValid(cardNumber))
            {
                Console.WriteLine();
                DisplayLine("Valid Card.Transaction approved.",ConsoleColor.Green);
            }
            else
            {
                throw new InvalidCardNumberException("Invalid card number.");
            }
        }

    }
}
