using System;
using iQuest.VendingMachine.PresentationLayer;
using System.Runtime.CompilerServices;
using iQuest.VendingMachine.Services;

[assembly: InternalsVisibleTo("TestProject")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace iQuest.VendingMachine.UseCases
{
    internal class LoginUseCase : IUseCase
    {
        private readonly IAuthentificationService authentificationService;
        private readonly IMainDisplay mainDisplay;

        public string Name => "login";

        public string Description => "Get access to administration buttons.";

        public bool CanExecute => !authentificationService.UserIsLoggedIn;

        public LoginUseCase(IAuthentificationService authentificationService,IMainDisplay mainDisplay)
        {
            this.authentificationService = authentificationService ?? throw new ArgumentNullException(nameof(authentificationService));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void Execute()
        {
            string password = mainDisplay.AskForPassword();

            authentificationService.Login(password);
        }
    }
}