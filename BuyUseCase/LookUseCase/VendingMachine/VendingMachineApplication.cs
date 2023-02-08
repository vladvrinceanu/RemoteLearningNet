using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Exceptions;
using System.Runtime.CompilerServices;
using iQuest.VendingMachine.Services;

[assembly: InternalsVisibleTo("TestProject")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly MainDisplay mainDisplay;
        private readonly ITurnOffService turnOffService;

        public VendingMachineApplication(List<IUseCase> useCases, MainDisplay mainDisplay, ITurnOffService turnOffService)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.turnOffService = turnOffService ?? throw new ArgumentNullException(nameof(turnOffService));
        }
    
        public void Run()
        {
            while (!turnOffService.TurnOffWasRequested)
            {
                IEnumerable<IUseCase> availableUseCases = useCases
                    .Where(x => x.CanExecute);

                IUseCase useCase = mainDisplay.ChooseCommand(availableUseCases);

                try
                {
                    useCase.Execute();
                }
                catch (InvalidColumnException e)
                {
                   mainDisplay.DisplayErrors(e);
                }
                catch (InsuficientStockException e)
                {
                    mainDisplay.DisplayErrors(e);
                }
                catch (CancelException e)
                {
                    mainDisplay.DisplayErrors(e);
                }
                catch (Exception e)
                {
                    mainDisplay.DisplayErrors(e);
                }
            }
        }
    }
}