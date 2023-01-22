using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.DataLayer
{
    internal class Product
    {
        public int ColumnId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
