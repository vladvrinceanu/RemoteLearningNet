using iQuest.VendingMachine.DataLayer;

namespace TestProject.BuyUseCaseFolder
{
    public class BuyUseCaseCanExecuteTests
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IAuthentificationService> authenticationService;
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentUseCase> paymentUseCase;
        public BuyUseCaseCanExecuteTests()
        {
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();
            paymentUseCase = new Mock<IPaymentUseCase>();

            authenticationService = new Mock<IAuthentificationService>();
        }
        [Fact]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(false);
            BuyUseCase buyUseCase = new BuyUseCase(authenticationService.Object, buyView.Object, productRepository.Object,paymentUseCase.Object);

            Assert.True(buyUseCase.CanExecute);
        }
        [Fact]
        public void HavingAdminLoggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(true);
            BuyUseCase buyUseCase = new BuyUseCase(authenticationService.Object, buyView.Object, productRepository.Object,paymentUseCase.Object);

            Assert.False(buyUseCase.CanExecute);
        }
    }
}
