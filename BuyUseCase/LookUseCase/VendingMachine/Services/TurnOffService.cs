using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Services
{
    internal class TurnOffService : ITurnOffService
    {
        private bool _turnOffWasRequested = false;
        public bool TurnOffWasRequested
        {
            get { return _turnOffWasRequested; }
            private set { _turnOffWasRequested = value; }
        }
        public void TurnOff()
        {
            TurnOffWasRequested = true;
        }
    }
}
