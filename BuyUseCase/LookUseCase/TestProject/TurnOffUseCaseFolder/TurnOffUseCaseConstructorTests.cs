using iQuest.VendingMachine.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.TurnOffUseCaseFolder
{
    public class TurnOffUseCaseConstructorTests
    {
        private readonly Mock<IAuthentificationService> authentificationService;
        private readonly Mock<ITurnOffService> turnOffService;

        public TurnOffUseCaseConstructorTests()
        {
            authentificationService = new Mock<IAuthentificationService>();    
            turnOffService = new Mock<ITurnOffService>();
        }

        [Fact]
        public void Constructor_Should_Throw_Exception_If_AuthentificationService_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new TurnOffUseCase(null,turnOffService.Object));
        }
        [Fact]
        public void Constructor_Should_Throw_Exception_If_TurnOffService_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new TurnOffUseCase(authentificationService.Object, null));
        }
        [Fact]
        public void Constructor_Should_Instantiate_Properties_If_All_Services_Are_Provided()
        {
            TurnOffUseCase lookUseCase = new TurnOffUseCase(authentificationService.Object, turnOffService.Object);

            Assert.NotNull(lookUseCase);
        }
    }
}
