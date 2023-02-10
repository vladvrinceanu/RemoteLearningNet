using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Services;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            MainDisplay mainDisplay = new MainDisplay();
            ShelfView shelfView = new ShelfView();
            ProductRepository productRepository = new ProductRepository();
            BuyView buyView = new BuyView();
            AuthentificationService authentificationService = new AuthentificationService();
            TurnOffService turnOffService = new TurnOffService();

            List<IUseCase> useCases = new List<IUseCase>();
            List<IPaymentAlgorithm> paymentAlgorithms = new List<IPaymentAlgorithm>();
            
            VendingMachineApplication vendingMachineApplication = new VendingMachineApplication(useCases, mainDisplay, turnOffService);
            PaymentUseCase paymentUseCase = new PaymentUseCase(paymentAlgorithms,buyView);

            useCases.AddRange(new IUseCase[]
            {
                new LoginUseCase(authentificationService, mainDisplay),
                new LogoutUseCase(authentificationService),
                new TurnOffUseCase(authentificationService,turnOffService),
                new LookUseCase(authentificationService,shelfView,productRepository),
                new BuyUseCase(authentificationService,buyView,productRepository,paymentUseCase)
            });

            paymentAlgorithms.AddRange(new IPaymentAlgorithm[]
            {
                new CashPayment { Name = "Cash payment." },
                new CardPayment { Name = "Card payment "}
            });

            return vendingMachineApplication;
        }
    } 
}