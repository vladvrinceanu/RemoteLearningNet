namespace CustomHashTable
{
    public class HashTable<TKey, TValue>
    {
        private LinkedList<KeyValuePair<TKey, TValue>>[] buckets;
        private float loadFactor;
        private int size;
        private int count;

        public HashTable(float loadFactor, int size)
        {
            this.loadFactor = loadFactor;
            this.size = size;
            this.buckets = new LinkedList<KeyValuePair<TKey, TValue>>[size];
        }
        public void Put(TKey key, TValue value)
        {
            int index = GetPosition(key);
            if (buckets[index] == null)
            {
                buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            foreach (KeyValuePair<TKey, TValue> pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                {
                    buckets[index].Remove(pair);
                    break;
                }
            }
            buckets[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            count++;
            if ((float)count / size >= loadFactor)
            {
                Resize();
            }
        }
        public bool ContainsKey(TKey key)
        {
            int index = GetPosition(key);
            if (buckets[index] != null)
            {
                foreach (KeyValuePair<TKey, TValue> pair in buckets[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int Count()
        {
            return count;
        }
        public TValue Get(TKey key)
        {
            int index = GetPosition(key);
            if (buckets[index] != null)
            {
                foreach (KeyValuePair<TKey, TValue> pair in buckets[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
            }
            throw new KeyNotFoundException("Key not found.");
        }
        private int GetPosition(TKey key)
        {
            var hash = key.GetHashCode();
            return Math.Abs(hash % size);
        }
        public void Resize()
        {
            int newSize = size * 2;
            LinkedList<KeyValuePair<TKey, TValue>>[] newBuckets = new LinkedList<KeyValuePair<TKey, TValue>>[newSize];
            foreach (LinkedList<KeyValuePair<TKey, TValue>> bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (KeyValuePair<TKey, TValue> pair in bucket)
                    {
                        int newIndex = Math.Abs(pair.Key.GetHashCode()) % newSize;
                        if (newBuckets[newIndex] == null)
                        {
                            newBuckets[newIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
                        }
                        newBuckets[newIndex].AddLast(pair);
                    }
                }
            }
            size = newSize;
            buckets = newBuckets;
        }
        public TValue this[TKey key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Put(key, value);
            }
        }
        public void Remove(TKey key)
        {
            int index = GetPosition(key);
            if (buckets[index] != null)
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[index].First;
                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        buckets[index].Remove(current);
                        count--;
                        return;
                    }
                    current = current.Next;
                }
            }
            throw new KeyNotFoundException("Key not found");
        }
    }
}