using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;

namespace iQuest.VendingMachine.DataLayer
{
    internal class LiteDbProductRepository : IProductRepository
    {
        private readonly LiteDatabase context;

        public LiteDbProductRepository(string connectionString)
        {
            context = new LiteDatabase(connectionString);

            var productCollection = this.context.GetCollection<Product>();
            if (IsDBEmpty())
            {
                var product = new List<Product>
                {
                  new Product { ColumnId = 1, Name = "Carte", Price = (float)25.5, Quantity = 10},
                  new Product { ColumnId = 2, Name = "Cana", Price = 15, Quantity = 5},
                  new Product { ColumnId = 3, Name = "Pix", Price = 5, Quantity = 20}
                };
                productCollection.InsertBulk(product);
            }
        }
        public IEnumerable<Product> GetAll()
        {
            var col = context.GetCollection<Product>();
            return col.FindAll().ToList();
        }
        public Product GetByColumn(int columnId)
        {
            var col = context.GetCollection<Product>();
            return col.Find(x => x.ColumnId == columnId).FirstOrDefault();
        }
        public void AddProduct(Product product)
        {
            var col = context.GetCollection<Product>();
            col.Insert(product);
        }
        public void DeleteProduct(string name)
        {
            var col = context.GetCollection<Product>();
            col.Delete(name);
        }
        private bool IsDBEmpty()
        {
            var col = context.GetCollection<Product>();
            if (col.Count() > 0)
            {
                return false;
            }
            return true;
        }
    }
}
