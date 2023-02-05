using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine.DataLayer;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ShelfView : DisplayBase , IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
               DisplayLine($"{product.ColumnId} {product.Name} {product.Price} {product.Quantity}",ConsoleColor.Green);
            }
        }
    }
}
