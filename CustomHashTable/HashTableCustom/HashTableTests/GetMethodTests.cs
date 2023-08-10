using CustomHashTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableTests
{
    public class GetMethodTests
    {
        [Fact]
        public void Get_ReturnValue()
        {
            var hashtable = new HashTable<string, int>(0.7f, 4);
            hashtable.Put("first", 1);

            int value = hashtable.Get("first");

            Assert.Equal(1, value);
        }
        [Fact]
        public void Get_ThrowsException()
        {
            var hashtable = new HashTable<string, int>(0.7f, 4);
            hashtable.Put("first", 1);

            Assert.Throws<KeyNotFoundException>(() => hashtable.Get("second"));
        }
    }
}
