namespace TestProject
{
   public class LoginUseCaseTests
    {
        [Fact]
        public void Test_Exectue_ValidPassword_UserIsLoggedInTrue()
        {
            var mockApplication = new Mock<VendingMachineApplication>();
            mockApplication.SetupProperty(a => a.UserIsLoggedIn,false);

            var mockMainDisplay = new Mock<MainDisplay>();
            mockMainDisplay.Setup(b => b.AskForPassword()).Returns("vlad");

            var loginUseCase = new LoginUseCase(mockApplication.Object, mockMainDisplay.Object);

            loginUseCase.Execute();

            Assert.True(mockApplication.Object.UserIsLoggedIn);
        }
        [Fact]
        public void Test_Execute_InvalidPassword_ThrowsException()
        {
            var mockApplication = new Mock<VendingMachineApplication>();
            mockApplication.SetupProperty(a => a.UserIsLoggedIn, false);

            var mockMainDisplay = new Mock<MainDisplay>();
            mockMainDisplay.Setup(x => x.AskForPassword()).Returns("invalid");

            var loginUseCase = new LoginUseCase(mockApplication.Object, mockMainDisplay.Object);

            var e = Assert.Throws<Exception>(()=>loginUseCase.Execute());
            Assert.Equal("Invalid password", e.Message);
        }
    }
}