using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.LogoutUseCaseFolder
{
    public class LogoutUseCaseExecuteTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly LogoutUseCase logoutUseCase;
        public LogoutUseCaseExecuteTests()
        {
            authentificationService = new Mock<IAuthentificationService>();

            logoutUseCase = new LogoutUseCase(authentificationService.Object);
        }
        [Fact]
        public void HavingALogoutUseCaseInstance_WhenExecuted_AndThenLogoutMethodCalled()
        {
            logoutUseCase.Execute();

            authentificationService.Verify(x => x.Logout(), Times.Once);
        }
    }
}

