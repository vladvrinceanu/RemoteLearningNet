using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("TestProject")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace iQuest.VendingMachine.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        private readonly VendingMachineApplication application;

        public string Name => "logout";

        public string Description => "Restrict access to administration buttons.";

        public bool CanExecute => application.UserIsLoggedIn;

        public LogoutUseCase(VendingMachineApplication application)
        {
            this.application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public void Execute()
        {
            application.UserIsLoggedIn = false;
        }
    }
}