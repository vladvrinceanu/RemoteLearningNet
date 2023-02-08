using System;
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
    }
}
