using iQuest.VendingMachine.Services;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class TurnOffUseCase : IUseCase
    {
        private readonly IAuthentificationService authentificationService;
        private readonly ITurnOffService turnOffService;

        public string Name => "exit";

        public string Description => "Go to live your life.";

        public bool CanExecute => authentificationService.UserIsLoggedIn;

        public TurnOffUseCase(IAuthentificationService authentificationService, ITurnOffService turnOffService)
        {
            this.authentificationService = authentificationService ?? throw new ArgumentNullException(nameof(authentificationService));
            this.turnOffService = turnOffService ?? throw new ArgumentNullException(nameof(turnOffService));
        }
        public void Execute() 
        {
          turnOffService.TurnOff();
        }
    }
}