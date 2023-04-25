namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface ICardPaymentTerminal
    {
        void ApprovedCardMessage();
        string AskForCardNumber();
        void DisplayChosenPaymentMethod();
        void DisplayPrice(float price);
    }
}