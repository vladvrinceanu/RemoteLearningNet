using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Services;
using System.IO;

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
            CashPaymentTerminal cashPaymentTerminal = new CashPaymentTerminal();
            CardPaymentTerminal cardPaymentTerminal = new CardPaymentTerminal();
            CardValidator cardValidator = new CardValidator();

            string path = @"C:\Data\ProductData.db";

            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            IProductRepository databaseProductRepositor = new LiteDbProductRepository(path);

            List<IUseCase> useCases = new List<IUseCase>();
            List<IPaymentAlgorithm> paymentAlgorithms = new List<IPaymentAlgorithm>();
            paymentAlgorithms.Add(new CashPayment (cashPaymentTerminal));
            paymentAlgorithms.Add(new CardPayment (cardPaymentTerminal, cardValidator));
            
            VendingMachineApplication vendingMachineApplication = new VendingMachineApplication(useCases, mainDisplay, turnOffService);
            PaymentUseCase paymentUseCase = new PaymentUseCase(paymentAlgorithms,buyView);

            useCases.AddRange(new IUseCase[]
            {
                new LoginUseCase(authentificationService, mainDisplay),
                new LogoutUseCase(authentificationService),
                new TurnOffUseCase(authentificationService,turnOffService),
                new LookUseCase(authentificationService,shelfView,databaseProductRepositor),
                new BuyUseCase(authentificationService,buyView,databaseProductRepositor,paymentUseCase)
            });
            return vendingMachineApplication;
        }
    } 
}