using iQuest.VendingMachine.Exceptions;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase, ICashPaymentTerminal
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
                throw new CancelException("Cancel");
            }
        }
        public void GiveBackChange(float change)
        {
            Console.WriteLine();
            DisplayLine($"Your change is: {change}", ConsoleColor.White);
        }
        public void DisplayPrice(float price)
        {
            Console.WriteLine();
            DisplayLine($"Price: {price}", ConsoleColor.White);
        }
        public void DisplayInsertedMoney(float insertedMoney)
        {
            Console.WriteLine();
            DisplayLine($"Inserted money: {insertedMoney}", ConsoleColor.White);
        }
        public void DisplayChosenPaymentMethod()
        {
            DisplayLine("Payment method: Cash", ConsoleColor.White);
        }
    }
}
