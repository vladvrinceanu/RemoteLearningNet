using CustomHashTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableTests
{
    public class RemoveMethodTests
    {
        [Fact]
        public void Remove_KeyValuePair()
        {
            var hashtable = new HashTable<string, int>(0.7f, 4);
            hashtable.Put("first", 1);
            hashtable.Put("second", 2);
            hashtable.Put("third", 3);

            hashtable.Remove("first");

            Assert.Equal(2, hashtable.Count());
            Assert.False(hashtable.ContainsKey("first"));
        }
        [Fact]
        public void Remove_ThrowsException()
        {
            var hashtable = new HashTable<string, int>(0.7f, 4);
            hashtable.Put("first", 1);
            Assert.Throws<KeyNotFoundException>(() => hashtable.Remove("second"));
        }
    }
}
