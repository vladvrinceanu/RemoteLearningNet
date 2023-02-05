using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.PresentationLayer
{
    public interface IBuyView
    {
        int RequestProduct();
        void DispenseProduct(string productName);
    }
}
