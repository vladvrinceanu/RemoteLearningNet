using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.Services
{
    internal class CashPayment : DisplayBase, IPaymentAlgorithm 
    {
        public string Name { get; set; }
        private CashPaymentTerminal cashPaymentTerminal;
        public void Run(float price)
        {
           cashPaymentTerminal = new CashPaymentTerminal();

           Console.WriteLine();
           DisplayLine("Payment method: Cash",ConsoleColor.White);
           DisplayLine($"Price: {price}",ConsoleColor.White);
           float? input = cashPaymentTerminal.AskForMoney();

           if(input > price)
            {
                cashPaymentTerminal.GiveBackChange((float)input - price);
            }
           if(input < price)
            {
                DisplayLine($"Insuficient funds.Please take back your money: {input}", ConsoleColor.Red);
                throw new CancelException("Insuficient funds.");
            }
        }
    }
}
