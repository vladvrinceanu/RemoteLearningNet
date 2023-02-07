
namespace TestProject.TurnOffUseCaseFolder
{
    public class TurnOffUseCaseExecuteTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<ITurnOffService> turnOffService;

        private readonly TurnOffUseCase turnOffUseCase;
        public TurnOffUseCaseExecuteTests()
        {
            authentificationService = new Mock<IAuthentificationService>();
            turnOffService = new Mock<ITurnOffService>();

            turnOffUseCase = new TurnOffUseCase(authentificationService.Object,turnOffService.Object);
        }
        [Fact]
        public void HavingTurnOffUseCaseInstance_WhenExecuted_ThenItTurnOffTheAppFromTurnOffServices()
        {
            turnOffUseCase.Execute();

            turnOffService.Verify( x => x.TurnOff(),Times.Once());
        }
    }
}
