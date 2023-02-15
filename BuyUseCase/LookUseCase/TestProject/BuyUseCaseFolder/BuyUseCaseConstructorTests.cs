using iQuest.VendingMachine.DataLayer;

namespace TestProject.BuyUseCaseFolder
{
    public class BuyUseCaseConstructorTests
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentUseCase> paymentUseCase;

        public BuyUseCaseConstructorTests()
        {
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();
            paymentUseCase = new Mock<IPaymentUseCase>();

            authentificationService = new Mock<IAuthentificationService>();
        }
        [Fact]
        public void Consctructor_Should_Throw_Exception_If_IPaymentUseCase_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(authentificationService.Object, buyView.Object, productRepository.Object,null));
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_ProductRepository_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(authentificationService.Object,buyView.Object,null,paymentUseCase.Object));
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_AuthentificationService_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(null,buyView.Object,productRepository.Object,paymentUseCase.Object));
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_BuyView_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(authentificationService.Object,null,productRepository.Object,paymentUseCase.Object));
        }
        [Fact]
        public void Constructor_Should_Instantiate_Properties_If_All_Services_Are_Provided()
        {
            BuyUseCase  buyUseCase = new BuyUseCase(authentificationService.Object,buyView.Object,productRepository.Object,paymentUseCase.Object);

            Assert.NotNull(buyUseCase);
            Assert.Equal("buy",buyUseCase.Name);
            Assert.Equal("Buy a product", buyUseCase.Description);
        }

    }
}