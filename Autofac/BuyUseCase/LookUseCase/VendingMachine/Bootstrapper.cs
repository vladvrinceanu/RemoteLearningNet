using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Services;
using System.Configuration;
using Autofac;
using System;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper 
    {
      public void Run()
        {
            var builder = new ContainerBuilder();
            string repoType = ConfigurationManager.AppSettings["repoType"];
            builder.RegisterModule(new AutofacModule(repoType));
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var useCases = scope.Resolve<IEnumerable<IUseCase>>();
                var mainDisplay = scope.Resolve<IMainDisplay>();
                var turnOffService = scope.Resolve<ITurnOffService>();
                var vendingMachineApplication = scope.Resolve<VendingMachineApplication>();
                vendingMachineApplication.Run();
            }
        }
    } 
}