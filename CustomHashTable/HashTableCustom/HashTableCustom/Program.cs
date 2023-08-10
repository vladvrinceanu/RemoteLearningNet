using CustomHashTable;
using System.Collections;

namespace Program
{
    public class ProgramHash
    {
        static void Main(string[] args)
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(0.7f, 16);
            hashTable.Put("One", 1);
            hashTable.Put("Two", 2);
            hashTable.Put("Three", 3);

            Console.WriteLine(hashTable["Two"]);

            hashTable.Put("Two", 22);
            Console.WriteLine(hashTable["Two"]);

            hashTable.Remove("One");
            Console.WriteLine(hashTable.ContainsKey("One"));

            Console.WriteLine(hashTable.Count());

        }
    }
}