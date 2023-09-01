namespace iQuest.VendingMachine.Services
{
    internal interface ICardValidator
    {
        bool IsCardNumberValid(string cardNumber);
    }
}