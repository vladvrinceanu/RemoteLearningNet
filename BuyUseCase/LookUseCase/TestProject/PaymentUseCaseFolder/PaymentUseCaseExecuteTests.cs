namespace VendingMachine.Tests.PaymentUseCaseFolder
{
    public class PaymentUseCaseExecuteTests
    {
        private readonly Mock<IBuyView> buyView;
        private readonly List<IPaymentAlgorithm> payments;
        private readonly PaymentUseCase paymentUseCase;
        public PaymentUseCaseExecuteTests()
        {
            buyView = new Mock<IBuyView>();

            payments = new List<IPaymentAlgorithm>();
            payments.Add(new Mock<IPaymentAlgorithm>().Object);
            payments.Add(new Mock<IPaymentAlgorithm>().Object);

            paymentUseCase = new PaymentUseCase(payments, buyView.Object);
        }
        [Fact]
        public void HavingABuyViewInstanceAskingForAPaymentMethod()
        {
            float price = 5;

            paymentUseCase.Execute(price);

            buyView.Verify(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<string>>()));
        }
        [Fact]
        public void ExecuteWithValidArgumentsShouldCallRunMethod()
        {
            var paymentAlgorithm1 = new Mock<IPaymentAlgorithm>();
            paymentAlgorithm1.Setup(x => x.Name).Returns("Cash payment");

            var paymentAlgorithm2 = new Mock<IPaymentAlgorithm>();
            paymentAlgorithm2.Setup(x => x.Name).Returns("Card payment");

            var paymentAlgorithms = new List<IPaymentAlgorithm>
            {
                paymentAlgorithm1.Object,
                paymentAlgorithm2.Object
            };

            buyView.Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<string>>())).Returns("Cash payment");
            float price = 5;

            var paymentUseCase = new PaymentUseCase(paymentAlgorithms, buyView.Object);

            paymentUseCase.Execute(price);

            paymentAlgorithm1.Verify(x => x.Run(price), Times.Once);
        }
    }
}
