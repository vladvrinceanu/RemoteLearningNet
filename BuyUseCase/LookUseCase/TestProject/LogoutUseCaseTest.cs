namespace TestProject
{
    public class LogoutUseCaseTest
    {
        [Fact]
        public void Test_Execute_UserIsLoggedInFalse()
        {
            var mockApplication = new Mock<VendingMachineApplication>();
            mockApplication.SetupProperty(a => a.UserIsLoggedIn, true);

            var logoutUseCase = new LogoutUseCase(mockApplication.Object);

            logoutUseCase.Execute();

            Assert.False(mockApplication.Object.UserIsLoggedIn);
        }
    }
}
