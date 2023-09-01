namespace TestProject.LoginUseCaseFolder
{
    public class LoginUseCaseExecuteTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<IMainDisplay> mainDisplay;
        private readonly LoginUseCase loginUseCase;
        public LoginUseCaseExecuteTests()
        {
            authentificationService = new Mock<IAuthentificationService>();
            mainDisplay = new Mock<IMainDisplay>();

            loginUseCase = new LoginUseCase(authentificationService.Object, mainDisplay.Object);
        }

        [Fact]
        public void HavingALoginUseCaseInstance_WhenExecuted_ThenItAsksForPasswordFromMainDisplayToPassItAuthentificationServiceLogin()
        {
            mainDisplay
                .Setup(x => x.AskForPassword())
                .Returns("vlad");

            loginUseCase.Execute();

            mainDisplay.Verify(x => x.AskForPassword(),Times.Once);
            authentificationService.Verify(x => x.Login("vlad"),Times.Once);
        }
        [Fact]
        public void HavingALoginUseCaseInstance_WhenExecuted_ThenItReceivesAnInvalidPassword()
        {
            mainDisplay
                .Setup(x => x.AskForPassword())
                .Returns("invalid");

            loginUseCase.Execute();

            mainDisplay.Verify(x => x.AskForPassword(), Times.Once);
            authentificationService.Verify(x => x.Login("invalid"), Times.Once);
        }
    }
}
