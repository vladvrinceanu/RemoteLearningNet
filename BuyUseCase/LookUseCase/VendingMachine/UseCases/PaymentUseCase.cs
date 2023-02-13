using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Services;
using System;
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
            this.paymentAlgorithms = paymentAlgorithms ?? throw new ArgumentNullException(nameof(paymentAlgorithms));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
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
