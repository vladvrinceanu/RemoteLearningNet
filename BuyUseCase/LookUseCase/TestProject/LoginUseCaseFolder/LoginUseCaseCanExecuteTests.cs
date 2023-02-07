namespace TestProject.LoginUseCaseFolder
{
    public class LoginUseCaseCanExecuteTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<IMainDisplay> mainDisplay;
        public LoginUseCaseCanExecuteTests()
        {
            authentificationService = new Mock<IAuthentificationService>();
            mainDisplay = new Mock<IMainDisplay>();
        }
        [Fact]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            authentificationService
                   .Setup(x => x.UserIsLoggedIn)
                   .Returns(false);
            LoginUseCase loginUseCase = new LoginUseCase(authentificationService.Object, mainDisplay.Object);

            Assert.True(loginUseCase.CanExecute);
        }
        [Fact]
        public void HavingAdminLoggedIn_CanExecuteIsFalse()
        {
            authentificationService
                  .Setup(x => x.UserIsLoggedIn)
                  .Returns(true);
            LoginUseCase loginUseCase = new LoginUseCase(authentificationService.Object, mainDisplay.Object);

            Assert.False(loginUseCase.CanExecute);
        }
    }
}
