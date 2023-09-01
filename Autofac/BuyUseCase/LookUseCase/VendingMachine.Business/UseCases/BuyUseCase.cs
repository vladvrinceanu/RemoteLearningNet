using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Services;
using System;
using VendingMachine.Business.Services;

namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IAuthentificationService authentificationService;
        private readonly IBuyView buyView;
        private readonly IProductRepository productRepository;
        private readonly IPaymentProcessor paymentProcessor;
       
        public string Name => "buy";

        public string Description => "Buy a product";

        public bool CanExecute => !authentificationService.UserIsLoggedIn;

        public BuyUseCase(IAuthentificationService authentificationService, IBuyView buyView, IProductRepository productRepository,IPaymentProcessor paymentProcessor)
        {
            this.authentificationService = authentificationService ?? throw new ArgumentNullException(nameof(authentificationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.paymentProcessor = paymentProcessor ?? throw new ArgumentNullException(nameof(paymentProcessor));
        }
        public void Execute()
        {
            int columnId = buyView.RequestProduct();
            var product = productRepository.GetByColumn(columnId);
            if(product == null)
            {
                throw new InvalidColumnException("Column not found.");
            }
            if (product.Quantity > 0)
            {
                paymentProcessor.ProcessPayment(product.Price);
                product.Quantity--;
                buyView.DispenseProduct(product.Name);
            }
            else
            {
                throw new InsuficientStockException("Insuficient stock.");
            }
        }           
    }
}

