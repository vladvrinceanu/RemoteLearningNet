namespace iQuest.VendingMachine.UseCases
{
    internal interface IPaymentUseCase
    {
        void Execute(float price);
    }
}