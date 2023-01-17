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
            int columnId = buyView.RequestProduct();
            bool found = false;

            foreach (var element in productRepository.GetAll())
            {
                if (element.ColumnId == columnId)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                var product = productRepository.GetByColumn(columnId);
                if (product.Quantity > 0)
                {
                    product.Quantity--;
                    buyView.DispenseProduct(product.Name);
                }
                else
                {
                    throw new InsuficientStockException("Insuficient stock.");
                }
            }
            else
            {
                throw new InvalidColumnException("Column not found.");
            }
        }
    }
}
