using iQuest.VendingMachine.DataLayer;

namespace TestProject.LookUseCaseFolder
{
    public class LookUseCaseConstructorTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<IShelfView> shelfView;
        private readonly Mock<IProductRepository> productRepository;

        public LookUseCaseConstructorTests()
        {
            authentificationService = new Mock<IAuthentificationService>();
            shelfView = new Mock<IShelfView>();
            productRepository = new Mock<IProductRepository>();
        }

        [Fact]
        public void Constructor_Should_Throw_Exception_If_AuthentificationService_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new LookUseCase(null,shelfView.Object,productRepository.Object));
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_ShelfView_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new LookUseCase(authentificationService.Object, null, productRepository.Object));
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_ProductRepository_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new LookUseCase(authentificationService.Object, shelfView.Object, null));
        }
        [Fact]
        public void Constructor_Should_Instantiate_Properties_If_All_Services_Are_Provided()
        {
            LookUseCase lookUseCase = new LookUseCase(authentificationService.Object,shelfView.Object,productRepository.Object);

            Assert.NotNull(lookUseCase);
            Assert.Equal("look", lookUseCase.Name);
            Assert.Equal("Look at the products.", lookUseCase.Description);
        }
    }
}
