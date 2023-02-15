using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Services;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IAuthentificationService authentificationService;
        private readonly IBuyView buyView;
        private readonly IProductRepository productRepository;
        private readonly IPaymentUseCase paymentUseCase;
       
        public string Name => "buy";

        public string Description => "Buy a product";

        public bool CanExecute => !authentificationService.UserIsLoggedIn;

        public BuyUseCase(IAuthentificationService authentificationService, IBuyView buyView, IProductRepository productRepository,IPaymentUseCase paymentUseCase)
        {
            this.authentificationService = authentificationService ?? throw new ArgumentNullException(nameof(authentificationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
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
                paymentUseCase.Execute(product.Price);
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

