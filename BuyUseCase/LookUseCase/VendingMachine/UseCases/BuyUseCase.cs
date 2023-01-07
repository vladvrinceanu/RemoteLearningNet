using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.DataLayer;
using System;
using iQuest.VendingMachine.Exceptions;


namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly VendingMachineApplication application;
        private readonly BuyView buyView;
        private readonly ProductRepository productRepository;
        

        public string Name => "buy";

        public string Description => "Buy a product";

        public bool CanExecute => !application.UserIsLoggedIn;

        public BuyUseCase(VendingMachineApplication application, BuyView buyView, ProductRepository productRepository)
        {
            this.application = application;
            this.buyView = buyView;
            this.productRepository = productRepository;
        }
        public void Execute()
        {
            int id = 0;
            int v = buyView.RequestProduct();

            if (v>=1 && v<=3)
            {
                id = v;
            }
            else
            {
                throw new InvalidColumnException("Invalid column id.");
            }

            var product = productRepository.GetByColumn(id);

            if (product.Quantit > 0)
            {
                product.Quantit--;
                buyView.DispenseProduct(product.Name);
            }
            else
            {
                throw new InsuficientStockException("Insuficient stock.");
            }
        }
    }
}
