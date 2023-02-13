using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.Services
{
    internal class CashPayment : DisplayBase, IPaymentAlgorithm 
    {
        public string Name { get; set; }
        private CashPaymentTerminal cashPaymentTerminal;
        public CashPayment (string name,CashPaymentTerminal cashPaymentTerminal)
        {
           Name = name;
           this.cashPaymentTerminal = cashPaymentTerminal;
        }
        public void Run(float price)
        {
           Console.WriteLine();
           DisplayLine("Payment method: Cash",ConsoleColor.White);
           DisplayLine($"Price: {price}",ConsoleColor.White);
           float insertedMoney = 0;
           while (insertedMoney < price)
           {
                try
                {
                    float? input = cashPaymentTerminal.AskForMoney();
                    insertedMoney += (float)input;
                }
                catch (InvalidInputException)
                {
                    cashPaymentTerminal.GiveBackChange(insertedMoney);
                    throw new CancelException("Transaction cancelled.");
                }
                if (insertedMoney > price)
                {
                    cashPaymentTerminal.GiveBackChange(insertedMoney - price);
                }
                if (insertedMoney < price)
                {
                    DisplayLine($"Inserted money: {insertedMoney}", ConsoleColor.White);
                }
           }
        }
    }
}
