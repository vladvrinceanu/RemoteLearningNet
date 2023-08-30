using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Services;
using System.Configuration;
using DocumentFormat.OpenXml.CustomProperties;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            string repoType = ConfigurationManager.AppSettings["repoType"];
            IProductRepository productRepository;
            switch (repoType)
            {
                case "Memory":
                    productRepository = new InMemoryProductRepository();
                    break;
                case "SQLite":
                    string connectionString = ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString;
                    productRepository = new SQLiteProductRepository(connectionString);
                    break;
                case "LiteDB":
                    string connectionString2 = ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString;
                    productRepository = new LiteDbProductRepository(connectionString2);
                    break;
                default:
                    throw new ConfigurationErrorsException("Invalid type.");
            }
            VendingMachineApplication vendingMachineApplication = BuildApplication(productRepository);
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication(IProductRepository productRepository)
        {
            MainDisplay mainDisplay = new MainDisplay();
            ShelfView shelfView = new ShelfView();
            BuyView buyView = new BuyView();
            AuthentificationService authentificationService = new AuthentificationService();
            TurnOffService turnOffService = new TurnOffService();
            CashPaymentTerminal cashPaymentTerminal = new CashPaymentTerminal();
            CardPaymentTerminal cardPaymentTerminal = new CardPaymentTerminal();
            CardValidator cardValidator = new CardValidator();

           
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
                new LookUseCase(authentificationService,shelfView, productRepository),
                new BuyUseCase(authentificationService,buyView,productRepository,paymentUseCase)
            });
            return vendingMachineApplication;
        }
    } 
}