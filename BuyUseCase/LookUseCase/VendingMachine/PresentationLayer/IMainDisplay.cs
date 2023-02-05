using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface IMainDisplay
    {
        IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);
        string AskForPassword();
        void DisplayErrors(Exception e);
    }
}
