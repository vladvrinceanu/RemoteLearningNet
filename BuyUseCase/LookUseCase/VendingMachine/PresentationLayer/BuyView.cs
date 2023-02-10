using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase , IBuyView
    {
        public int RequestProduct()
        {
            AskFromConsole("Type the product ID: ", ConsoleColor.Cyan);
            string typedId = Console.ReadLine();
            if (!string.IsNullOrEmpty(typedId) && !string.IsNullOrWhiteSpace(typedId))
            {
                bool success = int.TryParse(typedId, out int number);
                if (success)
                {
                    return number;
                }
                else
                {
                    throw new InvalidColumnException("Column must be an integer.");
                }
            }   
            else
            {
                throw new CancelException("Cancel.");
            }
        }
        public void DispenseProduct(string productName)
        {
            Console.WriteLine();
            DisplayLine($"{"You bought: "} {productName}",ConsoleColor.Green);
        }
        public string AskForPaymentMethod(IEnumerable<string> paymentMethods)
        {
            Console.WriteLine();
            AskFromConsole("Please select a payment method: ", ConsoleColor.Cyan);

            int i = 1; 

            foreach(string paymentMethod in paymentMethods)
            {
                Console.Write($"{i++}. {paymentMethod} ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Select: ");
            string choice = Console.ReadLine();

            int corect = int.Parse(choice) - 1;

            return paymentMethods.ElementAt(corect);
        }
    }
}
