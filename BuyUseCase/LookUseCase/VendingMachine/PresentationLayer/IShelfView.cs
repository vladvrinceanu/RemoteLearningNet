using iQuest.VendingMachine.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface IShelfView
    {
        void DisplayProducts(IEnumerable<Product> products);
    }
}
