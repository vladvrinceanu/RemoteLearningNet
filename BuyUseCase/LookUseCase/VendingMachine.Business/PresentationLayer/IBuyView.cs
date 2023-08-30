using iQuest.VendingMachine.DataLayer;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface IBuyView
    {
        int RequestProduct();
        void DispenseProduct(string productName);
        string AskForPaymentMethod(IEnumerable<string> paymentMethods);
    }
}
