using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
          foreach (Product product in products)
            {
                Console.WriteLine($"{product.ColumnId} {product.Name} {product.Price} {product.Quantit}");
            }
        }
    }
}
