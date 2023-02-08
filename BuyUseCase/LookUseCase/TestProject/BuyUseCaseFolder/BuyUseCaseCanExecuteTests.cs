using iQuest.VendingMachine.DataLayer;

namespace TestProject.BuyUseCaseFolder
{
    public class BuyUseCaseCanExecuteTests
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IAuthentificationService> authenticationService;
        private readonly Mock<IBuyView> buyView;
        public BuyUseCaseCanExecuteTests()
        {
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();

            authenticationService = new Mock<IAuthentificationService>();
        }
        [Fact]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(false);
            BuyUseCase buyUseCase = new BuyUseCase(authenticationService.Object, buyView.Object, productRepository.Object);

            Assert.True(buyUseCase.CanExecute);
        }
        [Fact]
        public void HavingAdminLoggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(true);
            BuyUseCase buyUseCase = new BuyUseCase(authenticationService.Object, buyView.Object, productRepository.Object);

            Assert.False(buyUseCase.CanExecute);
        }
    }
}
