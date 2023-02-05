using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.DataLayer
{
    internal interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetByColumn(int columnId);
    }
}
