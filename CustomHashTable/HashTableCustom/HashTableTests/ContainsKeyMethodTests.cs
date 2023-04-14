using CustomHashTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableTests
{
    public class ContainsKeyMethodTests
    {
        [Fact]
        public void ContainsKey_ReturnTrueIfKeyIsInTheHashTable()
        {
            var hashtable = new HashTable<string, int>(0.7f, 4);
            string key = "first";
            int value = 1;
            hashtable.Put(key, value);

            bool act = hashtable.ContainsKey(key);

            Assert.True(act);
        }
        [Fact]
        public void ContainsKey_ReturnFalseIfKeyIsNotInTheHashTable()
        {
            var hashtable = new HashTable<string, int>(0.7f, 4);
            string key = "random";

            bool act = hashtable.ContainsKey(key);

            Assert.False(act);
        }
    }
}
