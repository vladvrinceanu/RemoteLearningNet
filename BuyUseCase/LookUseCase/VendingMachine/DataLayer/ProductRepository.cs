using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine.DataLayer
{
    internal class ProductRepository : IProductRepository
    {
        private static List<Product> products = new List<Product>
        {
            new Product { ColumnId = 1, Name = "Carte", Price = (float)25.5, Quantity = 10},
            new Product { ColumnId = 2, Name = "Cana", Price = 15, Quantity = 5},
            new Product { ColumnId = 3, Name = "Pix", Price = 5, Quantity = 20}
        };
        public IEnumerable<Product> GetAll()
        {
            return products;
        }
        public Product GetByColumn(int columnId)
        {
            return products.FirstOrDefault(x => x.ColumnId == columnId);
        }
    }
}
