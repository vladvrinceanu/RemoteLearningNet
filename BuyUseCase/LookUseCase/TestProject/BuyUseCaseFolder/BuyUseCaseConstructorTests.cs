using iQuest.VendingMachine.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BuyUseCaseFolder
{
    public class BuyUseCaseConstructorTests
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<IBuyView> buyView;

        public BuyUseCaseConstructorTests()
        {
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();

            authentificationService = new Mock<IAuthentificationService>();
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_ProductRepository_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(authentificationService.Object,buyView.Object,null));
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_AuthentificationService_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(null,buyView.Object,productRepository.Object));
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_BuyView_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(authentificationService.Object,null,productRepository.Object));
        }
        [Fact]
        public void Constructor_Should_Instantiate_Properties_If_All_Services_Are_Provided()
        {
            BuyUseCase  buyUseCase = new BuyUseCase(authentificationService.Object,buyView.Object,productRepository.Object);

            Assert.NotNull(buyUseCase);
        }

    }
}