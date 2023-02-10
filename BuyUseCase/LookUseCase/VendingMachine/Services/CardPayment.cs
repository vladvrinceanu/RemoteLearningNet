using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.Services
{
    internal class CardPayment : DisplayBase, IPaymentAlgorithm
    {
        public string Name { get; set; }
        private CardPaymentTerminal cardPaymentTerminal;
        public void Run(float price)
        {
            cardPaymentTerminal = new CardPaymentTerminal();

            Console.WriteLine();
            DisplayLine("Payment method: Card", ConsoleColor.White);
            DisplayLine($"Price: {price}", ConsoleColor.White);
            string cardNumber = cardPaymentTerminal.AskForCardNumber();

            static bool CardNumberIsValid(string cardNumber)
            {
                int sum = 0;
                bool secondNumber = false;
                for (int i = cardNumber.Length - 1; i >= 0; i--)
                {
                    int n = int.Parse(cardNumber[i].ToString());
                    if(secondNumber)
                    {
                        n *= 2;
                        if(n > 9)
                        {
                            n = (n%10) + (n/10);
                        }
                    }
                    sum += n;
                    secondNumber = !secondNumber;
                }
                return (sum % 10 == 0);
            }
            if (CardNumberIsValid(cardNumber))
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
