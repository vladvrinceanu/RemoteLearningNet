using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace iQuest.VendingMachine
{
    internal class ProductRepository
    {
        private static List<Product> products = new List<Product>
        {
            new Product { ColumnId = 1, Name = "Carte", Price = (float)25.5, Quantit = 10},
            new Product { ColumnId = 2, Name = "Cana", Price = 15, Quantit = 5},
            new Product { ColumnId = 3, Name = "Pix", Price = 5, Quantit = 20}
        };
        public IEnumerable<Product> GetAll()
        {
            return products;
        }
    }
}
