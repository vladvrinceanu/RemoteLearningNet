using iQuest.VendingMachine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Tests.PaymentUseCaseFolder
{
    public class CashPaymentCanRunTests
    {
        private readonly Mock<ICashPaymentTerminal> terminal;
        private readonly CashPayment cashPayment;

        public CashPaymentCanRunTests()
        {
            terminal = new Mock<ICashPaymentTerminal>();
            cashPayment = new CashPayment(terminal.Object);
        }
        [Fact]
        public void WhilePaying_CommandIsCanceled_ThrowsExceptionAndReleaseMoney()
        {
            float price = 7;
            terminal
                .SetupSequence(x => x.AskForMoney())
                .Returns(1)
                .Returns(4)
                .Throws(new CancelException("Cancel."));

            Assert.Throws<CancelException>(() => cashPayment.Run(price));
            terminal.Verify(x => x.GiveBackChange(5), Times.Once);
        }
    }
}
