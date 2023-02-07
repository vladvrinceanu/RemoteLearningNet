namespace iQuest.VendingMachine.Services
{
    internal interface ITurnOffService
    {
        public bool TurnOffWasRequested { get; }
        public void TurnOff();
    }
}
