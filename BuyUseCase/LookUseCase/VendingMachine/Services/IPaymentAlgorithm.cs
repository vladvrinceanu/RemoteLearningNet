namespace iQuest.VendingMachine.Services
{
    internal interface IPaymentAlgorithm
    {
        string Name { get; }
        void Run(float price);
    }
}
