using iQuest.VendingMachine.DataLayer;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface IShelfView
    {
        void DisplayProducts(IEnumerable<Product> products);
    }
}
