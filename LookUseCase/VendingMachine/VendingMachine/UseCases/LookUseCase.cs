using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase

    {
        private readonly VendingMachineApplication application;
        private readonly ShelfView shelfView;
        private readonly ProductRepository productRepository;
        public string Name => "look";

        public string Description => "Look at the products";

        public bool CanExecute => application.UserIsLoggedIn;

        public LookUseCase(VendingMachineApplication application, ShelfView shelfView, ProductRepository productRepository)
        {
            this.application = application;
            this.shelfView = shelfView;
            this.productRepository = productRepository;
        }

        public void Execute()
        {
            application.UserIsLoggedIn = true;
            shelfView.DisplayProducts(productRepository.GetAll());
        }
    }
}
