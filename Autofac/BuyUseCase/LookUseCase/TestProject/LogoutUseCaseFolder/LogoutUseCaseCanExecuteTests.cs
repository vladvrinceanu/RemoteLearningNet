namespace TestProject.LogoutUseCaseFolder
{
    public class LogoutUseCaseCanExecuteTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;

        public LogoutUseCaseCanExecuteTests()
        {
            authentificationService = new Mock<IAuthentificationService>();
        }
        [Fact]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            authentificationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(false);
            LogoutUseCase logoutUseCase = new LogoutUseCase(authentificationService.Object);

            Assert.False(logoutUseCase.CanExecute);
        }
        [Fact]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            authentificationService
                .Setup(x => x.UserIsLoggedIn)
                .Returns(true);
            LogoutUseCase logoutUseCase = new LogoutUseCase(authentificationService.Object);

            Assert.True(logoutUseCase.CanExecute);
        }
    }
}
