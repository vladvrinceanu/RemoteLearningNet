using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.Services
{
    internal class CardPayment : DisplayBase, IPaymentAlgorithm
    {
        public string Name => "Card payment.";
        private ICardPaymentTerminal cardPaymentTerminal;
        private ICardValidator cardValidator;
        public CardPayment(ICardPaymentTerminal cardPaymentTerminal, ICardValidator cardValidator)
        { 
            this.cardPaymentTerminal = cardPaymentTerminal;
            this.cardValidator = cardValidator;
        }
        public void Run(float price)
        {
            cardPaymentTerminal.DisplayChosenPaymentMethod();
            string cardNumber = cardPaymentTerminal.AskForCardNumber();
            cardPaymentTerminal.DisplayPrice(price);
            if (cardValidator.IsCardNumberValid(cardNumber))
            {
                cardPaymentTerminal.ApprovedCardMessage();
            }
            else
            {
                throw new InvalidCardNumberException("Invalid card number.");
            }
        }

    }
}
