using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;
using VendingMachine.Business.Services;

namespace iQuest.VendingMachine
{
    internal class AutofacModule : Module
    {
        private readonly string repoType;
        public AutofacModule(string repoType)
        {
            this.repoType = repoType;
        }
        protected override void Load(ContainerBuilder builder)
        { 
            switch (repoType)
            {
                case "Memory":
                    builder.RegisterType<InMemoryProductRepository>().As<IProductRepository>();
                    break;
                case "SQLite":
                    string connectionString = ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString;
                    builder.RegisterType<SQLiteProductRepository>().As<IProductRepository>().WithParameter("connectionString", connectionString);
                    break;
                case "LiteDB":
                    string connectionString2 = ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString;
                    builder.RegisterType<LiteDbProductRepository>().As<IProductRepository>().WithParameter("connectionString", connectionString2);
                    break;
                default:
                    throw new ConfigurationErrorsException("Invalid type.");
            }

            builder.RegisterAssemblyTypes(typeof(AutofacModule).Assembly)
                 .Where(x => x.Name.EndsWith("Service") || x.Name.EndsWith("UseCase"))
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

            builder.RegisterType<CashPayment>().As<IPaymentAlgorithm>()
               .WithParameter("cashPaymentTerminal", new CashPaymentTerminal());
            builder.RegisterType<CardPayment>().As<IPaymentAlgorithm>()
                .WithParameter("cardPaymentTerminal", new CardPaymentTerminal())
                .WithParameter("cardValidator", new CardValidator());

            builder.RegisterType<List<IPaymentAlgorithm>>()
                .As<IEnumerable<IPaymentAlgorithm>>()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(IUseCase).Assembly)
                .Where(t => typeof(IUseCase).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<PaymentProcessor>()
                .As<IPaymentProcessor>()
                .WithParameter((x, y) => x.ParameterType == typeof(IPaymentUseCase),
                       (x, y) => y.Resolve<IPaymentUseCase>())
                .WithParameter((x, y) => x.ParameterType == typeof(IEnumerable<IPaymentAlgorithm>),
                       (x, y) => y.Resolve<IEnumerable<IPaymentAlgorithm>>());


            builder.RegisterType<MainDisplay>().As<IMainDisplay>();
            builder.RegisterType<ShelfView>().As<IShelfView>();
            builder.RegisterType<BuyView>().As<IBuyView>();
            builder.RegisterType<TurnOffService>().As<ITurnOffService>();
            builder.RegisterType<AuthentificationService>().As<IAuthentificationService>();
            builder.RegisterType<PaymentUseCase>().As<IPaymentUseCase>();


            builder.RegisterType<VendingMachineApplication>().AsSelf().SingleInstance();
        }
    }
}
