using iQuest.VendingMachine.Exceptions;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase
    {
        public float? AskForMoney()
        {
            Console.WriteLine();
            AskFromConsole("Please insert the money: ", ConsoleColor.Cyan);
            string amount = Console.ReadLine();
            if (float.TryParse(amount, out float value))
            {
                return value;
            }
            else
            {
                throw new InvalidInputException("Invalid input.");
            }
        }
        public void GiveBackChange(float change)
        {
            Console.WriteLine();
            DisplayLine($"Your change is: {change}", ConsoleColor.White);
        }
    }
}
