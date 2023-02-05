using iQuest.VendingMachine.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BuyUseCaseFolder
{
    public class BuyUseCaseExecuteTests
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<IBuyView> buyView;
        public BuyUseCaseExecuteTests()
        {
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();

            authentificationService = new Mock<IAuthentificationService>();
        }
        [Fact]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            authentificationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(false);
            BuyUseCase buyUseCase = new BuyUseCase(authentificationService.Object, buyView.Object, productRepository.Object);

            Assert.True(buyUseCase.CanExecute);
        }

        [Fact]
        public void HavingAdminLoggedIn_CanExecuteIsFalse()
        {
            authentificationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(true);
            BuyUseCase buyUseCase = new BuyUseCase(authentificationService.Object, buyView.Object, productRepository.Object);

            Assert.False(buyUseCase.CanExecute);
        }
    }
}
