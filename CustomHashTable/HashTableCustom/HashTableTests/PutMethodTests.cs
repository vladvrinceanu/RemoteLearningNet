using CustomHashTable;

namespace HashTableTests
{
    public class PutMethodTests
    {
        [Fact]
        public void Put_AddNewKeyValuePair()
        {
            var hashtable = new HashTable<string, int>(0.7f, 4);
            string key = "key";
            int value = 12;

            hashtable.Put(key, value);

            Assert.True(hashtable.ContainsKey(key));
            Assert.Equal(value, hashtable[key]);
            Assert.Equal(1, hashtable.Count());
        }
        [Fact]
        public void Put_UpdateKeyValuePair()
        {
            var hashTable = new HashTable<string, int>(0.7f, 4);
            string key = "key";
            int value1 = 12;
            int value2 = 20;

            hashTable.Put(key, value1);
            hashTable.Put(key, value2);

            Assert.True(hashTable.ContainsKey(key));
            Assert.Equal(value2,hashTable[key]);
            Assert.Equal(2,hashTable.Count());
        }
        [Fact]
        public void Put_ResizeTheTable()
        {
            var hashTable = new HashTable<string, int>(0.7f, 4);
            string key1 = "first";
            string key2 = "second";
            string key3 = "third";
            string key4 = "fourth";
            int value1 = 12;
            int value2 = 13;
            int value3 = 14;
            int value4 = 15;

            hashTable.Put(key1, value1);
            hashTable.Put(key2, value2);
            hashTable.Put(key3, value3);

            hashTable.Put(key4 , value4);

            Assert.Equal(4,hashTable.Count());
            Assert.True(hashTable.ContainsKey(key1));
            Assert.True(hashTable.ContainsKey(key2));
            Assert.True(hashTable.ContainsKey(key3));
            Assert.True(hashTable.ContainsKey(key4));
        }
    }
}