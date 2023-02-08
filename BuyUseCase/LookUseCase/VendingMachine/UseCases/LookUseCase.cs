using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Services;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase

    {
        private readonly IAuthentificationService authentificationService;
        private readonly IShelfView shelfView;
        private readonly IProductRepository productRepository;
        public string Name => "look";

        public string Description => "Look at the products.";

        public bool CanExecute => !authentificationService.UserIsLoggedIn || authentificationService.UserIsLoggedIn;

        public LookUseCase(IAuthentificationService authentificationService, IShelfView shelfView, IProductRepository productRepository)
        {
            this.authentificationService = authentificationService ?? throw new ArgumentNullException(nameof(authentificationService));
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void Execute()
        {
            shelfView.DisplayProducts(productRepository.GetAll());
        }
    }
}
