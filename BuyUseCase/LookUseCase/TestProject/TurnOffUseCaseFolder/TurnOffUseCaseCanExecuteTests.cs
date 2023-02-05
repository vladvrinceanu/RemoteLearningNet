using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.TurnOffUseCaseFolder
{
    public class TurnOffUseCaseCanExecuteTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<ITurnOffService> turnOffService;

        public TurnOffUseCaseCanExecuteTests()
        {
            authentificationService = new Mock<IAuthentificationService>();
            turnOffService = new Mock<ITurnOffService>();
        }
        [Fact]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            authentificationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(false);
            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(authentificationService.Object,turnOffService.Object);

            Assert.False(turnOffUseCase.CanExecute);
        }
        [Fact]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            authentificationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(true);
            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(authentificationService.Object, turnOffService.Object);

            Assert.True(turnOffUseCase.CanExecute);
        }
    }
}
