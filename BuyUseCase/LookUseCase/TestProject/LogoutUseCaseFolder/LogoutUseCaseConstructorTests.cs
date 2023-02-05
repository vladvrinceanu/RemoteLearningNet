namespace TestProject.LogoutUseCaseFolder
{
    public class LogoutUseCaseConstructorTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;

        public LogoutUseCaseConstructorTests()
        {
            authentificationService = new Mock<IAuthentificationService>();
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_AuthentificationService_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new LogoutUseCase(null));
        }
        [Fact]
        public void Constructor_Should_Instantiate_Properties_If_All_Services_Are_Provided()
        {
            LogoutUseCase logoutUseCase = new LogoutUseCase(authentificationService.Object);

            Assert.NotNull(logoutUseCase);
        }
    }
}
