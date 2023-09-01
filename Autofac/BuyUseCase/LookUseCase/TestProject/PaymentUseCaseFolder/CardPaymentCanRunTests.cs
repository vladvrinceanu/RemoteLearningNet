using iQuest.VendingMachine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Tests.PaymentUseCaseFolder
{
    public class CardPaymentCanRunTests
    {
        private readonly Mock<ICardPaymentTerminal> cardPaymentTerminal;
        private readonly Mock<ICardValidator> cardValidator;

        private readonly CardPayment cardPayment;
        public CardPaymentCanRunTests()
        {
            cardPaymentTerminal = new Mock<ICardPaymentTerminal>();
            cardValidator = new Mock<ICardValidator>();

            cardPayment = new CardPayment(cardPaymentTerminal.Object, cardValidator.Object);
        }
        [Fact]
        public void While_Paying_TheCardNumberIsInvalid()
        {
            float price = 10;
            string invalidCardNumber = "1234";

            cardPaymentTerminal
                .Setup(x => x.AskForCardNumber())
                .Returns(invalidCardNumber);

            cardValidator
                .Setup(x => x.IsCardNumberValid(invalidCardNumber))
                .Returns(false);

            Assert.Throws<InvalidCardNumberException>(() => cardPayment.Run(price));

            cardPaymentTerminal.Verify(x => x.DisplayChosenPaymentMethod(),Times.Once);
            cardPaymentTerminal.Verify(x => x.DisplayPrice(price),Times.Once);
            cardValidator.Verify(x => x.IsCardNumberValid(invalidCardNumber),Times.Once);
        }
        [Fact]
        public void While_Paying_TheCardNumberIsValid()
        {
            float price = 10;
            string cardNumber = "79927398713";

            cardPaymentTerminal
                .Setup(x => x.AskForCardNumber())
                .Returns(cardNumber);

            cardValidator
                .Setup(x => x.IsCardNumberValid(cardNumber))
                .Returns(true);

            cardPayment.Run(price);

            cardPaymentTerminal.Verify(x => x.ApprovedCardMessage());
        }
    }
}
