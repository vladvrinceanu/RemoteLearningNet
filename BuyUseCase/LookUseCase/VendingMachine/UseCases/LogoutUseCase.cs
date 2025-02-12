﻿using iQuest.VendingMachine.Services;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        private readonly IAuthentificationService authentificationService;
      
        public string Name => "logout";

        public string Description => "Restrict access to administration buttons.";

        public bool CanExecute => authentificationService.UserIsLoggedIn;

        public LogoutUseCase(IAuthentificationService authentificationService)
        {
            this.authentificationService = authentificationService ?? throw new ArgumentNullException(nameof(authentificationService));
        }
        public void Execute()
        {
            authentificationService.Logout();   
        }
    }
}