namespace iQuest.VendingMachine.PresentationLayer
{
    public interface IBuyView
    {
        int RequestProduct();
        void DispenseProduct(string productName);
    }
}
