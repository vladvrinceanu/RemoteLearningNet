using iQuest.VendingMachine.DataLayer;

namespace TestProject.LookUseCaseFolder
{
    public class LookUseCaseExecuteTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<IShelfView> shelfView;
        private readonly Mock<IProductRepository> productRepository;
        private readonly LookUseCase lookUseCase;

        public LookUseCaseExecuteTests()
        {
            authentificationService = new Mock<IAuthentificationService>();
            shelfView = new Mock<IShelfView>();
            productRepository = new Mock<IProductRepository>();

            lookUseCase = new LookUseCase(authentificationService.Object,shelfView.Object,productRepository.Object);
        }
        [Fact]
        public void HavingALookUseCaseInstance_WhenExecuted_ThenItDisplaysTheProductsFromProductsRepository()
        {

            productRepository.Setup(x => x.GetAll()).Returns(new List<Product>());
            lookUseCase.Execute();

            shelfView.Verify(x => x.DisplayProducts(It.IsAny<List<Product>>()),Times.Once);
        }
    }
}
