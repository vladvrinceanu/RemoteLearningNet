namespace TestProject.LogoutUseCaseFolder
{
    public class LoginUseCaseConstructorTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<IMainDisplay> mainDisplay;
        public LoginUseCaseConstructorTests()
        {
            authentificationService = new Mock<IAuthentificationService>();
            mainDisplay = new Mock<IMainDisplay>();
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_AuthentificationService_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new LoginUseCase(null, mainDisplay.Object));
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_MainDisplay_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new LoginUseCase(authentificationService.Object,null));
        }
        [Fact]
        public void Constructor_Should_Instantiate_Properties_If_Both_Services_Are_Provided()
        {
            LoginUseCase loginUseCase = new LoginUseCase(authentificationService.Object, mainDisplay.Object);

            Assert.NotNull(loginUseCase);
        }
    }
}