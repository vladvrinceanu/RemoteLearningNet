using iQuest.VendingMachine.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.LookUseCaseFolder
{
    public class LookUseCaseCanExecuteTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<IShelfView> shelfView;
        private readonly Mock<IProductRepository> productRepository;

        public LookUseCaseCanExecuteTests()
        {
            authentificationService = new Mock<IAuthentificationService>();
            shelfView = new Mock<IShelfView>();
            productRepository = new Mock<IProductRepository>();
        }

        [Fact]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            authentificationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(false);
            LookUseCase lookUseCase = new LookUseCase(authentificationService.Object, shelfView.Object, productRepository.Object);

            Assert.True(lookUseCase.CanExecute);
        }
        [Fact]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            authentificationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(true);
            LookUseCase lookUseCase = new LookUseCase(authentificationService.Object, shelfView.Object, productRepository.Object);

            Assert.True(lookUseCase.CanExecute);
        }
    }
}
