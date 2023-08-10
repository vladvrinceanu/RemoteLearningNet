using CustomHashTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableTests
{
    public class ResizeMethodTests
    {
        public void Resize_DoubleTheSizeOfTheTable()
        {
            var hashtable = new HashTable<string, int>(0.7f, 4);
            hashtable.Put("first", 1);
            hashtable.Put("second", 2);
            hashtable.Put("third", 3);

            hashtable.Resize();

            Assert.Equal(3, hashtable.Count());
            hashtable.Put("fourth", 4);
            Assert.Equal(4, hashtable.Count());
        }
    }
}
