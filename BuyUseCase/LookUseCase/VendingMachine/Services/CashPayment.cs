using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.Services
{
    internal class CashPayment : DisplayBase, IPaymentAlgorithm 
    {
        public string Name => "Cash payment.";
        private ICashPaymentTerminal cashPaymentTerminal;
        public CashPayment (ICashPaymentTerminal cashPaymentTerminal)
        {
           this.cashPaymentTerminal = cashPaymentTerminal;
        }
        public void Run(float price)
        {
           float insertedMoney = 0;
           cashPaymentTerminal.DisplayChosenPaymentMethod();
           while (insertedMoney < price)
           {
                try
                {
                    cashPaymentTerminal.DisplayPrice(price);
                    float? input = cashPaymentTerminal.AskForMoney();
                    insertedMoney += (float)input;
                }
                catch (CancelException)
                {
                    cashPaymentTerminal.GiveBackChange(insertedMoney);
                    throw;
                }
                if (insertedMoney > price)
                {
                    cashPaymentTerminal.GiveBackChange(insertedMoney - price);
                }
                if (insertedMoney < price)
                {
                    cashPaymentTerminal.DisplayInsertedMoney(insertedMoney);
                }
            }
        }
    }
}
