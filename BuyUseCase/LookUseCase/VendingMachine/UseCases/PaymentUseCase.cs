using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Services;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private List<IPaymentAlgorithm> paymentAlgorithms ;
        private IBuyView buyView;
        public PaymentUseCase(List<IPaymentAlgorithm> paymentAlgorithms,IBuyView buyView)
        {
            this.paymentAlgorithms = paymentAlgorithms;
            this.buyView = buyView;
        }
        public void Execute(float price)
        {
            IEnumerable<string> paymentNames = paymentAlgorithms.Select(pa => pa.Name);

            string selectedPaymentName = buyView.AskForPaymentMethod(paymentNames);

            IPaymentAlgorithm selectedPaymentAlgorithm = paymentAlgorithms.FirstOrDefault(pa => pa.Name == selectedPaymentName);

            selectedPaymentAlgorithm.Run(price);
        }
    }
}
