namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface ICashPaymentTerminal
    {
        float? AskForMoney();
        void DisplayChosenPaymentMethod();
        void DisplayInsertedMoney(float insertedMoney);
        void DisplayPrice(float price);
        void GiveBackChange(float change);
    }
}