using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Business.Services
{
    internal class PaymentProcessor : IPaymentProcessor
    {
        public IPaymentUseCase paymentUseCase;
        public List<IPaymentAlgorithm> paymentAlgorithms;

        public PaymentProcessor(IPaymentUseCase paymentUsecase, List<IPaymentAlgorithm> paymentAlgorithms)
        {
            this.paymentUseCase = paymentUsecase;
            this.paymentAlgorithms = paymentAlgorithms;
        }

        public void ProcessPayment(float amount) 
        {
            paymentUseCase.Execute(amount);
        }
    }
}
