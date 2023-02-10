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
            if (!string.IsNullOrEmpty(amount) && !string.IsNullOrWhiteSpace(amount))
            {
                if (float.TryParse(amount, out float value) && value > 0)
                {
                    return value;
                }
                else
                {
                    throw new InvalidInputException("Invalid input.");
                }
            }
            else
            {
                throw new CancelException("Cancel.");
            }
        }
        public void GiveBackChange(float change)
        {
            DisplayLine($"Your change is: {change}", ConsoleColor.White);
        }
    }
}
