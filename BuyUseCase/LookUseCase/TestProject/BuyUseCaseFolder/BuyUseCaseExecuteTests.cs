using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Exceptions;

namespace TestProject.BuyUseCaseFolder
{
    public class BuyUseCaseExecuteTests
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<IBuyView> buyView;

        private readonly BuyUseCase buyUseCase;
        public BuyUseCaseExecuteTests()
        {
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();

            authentificationService = new Mock<IAuthentificationService>();
            buyUseCase = new BuyUseCase(authentificationService.Object,buyView.Object,productRepository.Object);
        }
        [Fact]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThenItRequestsFromProductRepositoryTheProductWithTheIdReceivedFromBuyView()
        {
            buyView
                .Setup(x => x.RequestProduct())
                .Returns(101);
            productRepository
                .Setup(x => x.GetByColumn(It.IsAny<int>()))
                .Returns(new Product {Quantity = 1});

            buyUseCase.Execute();

            productRepository.Verify(x => x.GetByColumn(101),Times.Once());
        }
        [Fact]
        public void BuyUseCase_Should_Throw_InvalidColumnException_If_RequestProduct_Is_Null()
        {
            buyView
                .Setup(x => x.RequestProduct())
                .Returns(null);

            Assert.Throws<InvalidColumnException>(() => buyUseCase.Execute());
        }
        [Fact]
        public void BuyUseCase_Should_Throw_InsuficientStockException_If_ProductRepository_Quantity_Is_Zero()
        {
            productRepository
                 .Setup(x => x.GetByColumn(It.IsAny<int>()))
                 .Returns(new Product { Quantity = 0 });

            Assert.Throws<InsuficientStockException>(() => buyUseCase.Execute());
        }
    }
}
