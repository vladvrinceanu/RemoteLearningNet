namespace VendingMachine.Tests.PaymentUseCaseFolder
{
    public class PaymentUseCaseConstructorTests
    {
        private readonly Mock<IBuyView> buyView;
        private readonly List<IPaymentAlgorithm> payments;
        public PaymentUseCaseConstructorTests()
        {
            buyView = new Mock<IBuyView>();

            payments = new List<IPaymentAlgorithm>();
            payments.Add(new Mock<IPaymentAlgorithm>().Object);
            payments.Add(new Mock<IPaymentAlgorithm>().Object);
        }

        [Fact]
        public void Consctructor_Should_Throw_Exception_If_IPaymentUseCase_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new PaymentUseCase(null,buyView.Object));
        }
        [Fact]
        public void Consctructor_Should_Throw_Exception_If_BuyView_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new PaymentUseCase(payments, null));
        }
        [Fact]
        public void Constructor_Should_Instantiate_Properties_If_All_Services_Are_Provided()
        {
            PaymentUseCase paymentUseCase = new PaymentUseCase(payments, buyView.Object);

            Assert.NotNull(paymentUseCase);
        }
    }
}
