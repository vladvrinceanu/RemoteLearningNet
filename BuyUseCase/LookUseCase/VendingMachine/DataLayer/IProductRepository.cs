using System.Collections.Generic;

namespace iQuest.VendingMachine.DataLayer
{
    internal interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetByColumn(int columnId);
    }
}
