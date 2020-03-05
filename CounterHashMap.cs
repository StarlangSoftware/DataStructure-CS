using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{
    public class CounterHashMap<TKey> : Dictionary<TKey, int>
    {
        /**
         * A constructor which calls its super.
         */
        public CounterHashMap()
        {
        }

        /**
         * The put method takes a K type input. If this map contains a mapping for the key, it puts this key after
         * incrementing its value by one. If his map does not contain a mapping, then it directly puts key with the value of 1.
         *
         * @param key to put.
         */
        public void Put(TKey key)
        {
            if (ContainsKey(key))
            {
                Add(key, this[key] + 1);
            }
            else
            {
                Add(key, 1);
            }
        }

        /**
         * The putNTimes method takes a K and an integer N as inputs. If this map contains a mapping for the key, it puts this key after
         * incrementing its value by N. If his map does not contain a mapping, then it directly puts key with the value of N.
         *
         * @param key to put.
         * @param N   to increment value.
         */
        public void PutNTimes(TKey key, int N)
        {
            if (ContainsKey(key))
            {
                Add(key, this[key] + N);
            }
            else
            {
                Add(key, N);
            }
        }
        
        /**
        * The count method takes a K as input, if this map contains a mapping for the key, it returns the value corresponding
        * this key, 0 otherwise.
        *
        * @param key to get value.
        * @return the value corresponding given key, 0 if it is not mapped.
        */
        public int Count(TKey key)
        {
            return ContainsKey(key) ? this[key] : 0;
        }

        /**
         * The sumOfCounts method loops through the values contained in this map and accumulates the counts of this values.
         *
         * @return accumulated counts.
         */
        public int SumOfCounts()
        {
            return this.Values.Sum();
        }

        /**
         * The max method loops through the mappings contained in this map and if the current entry's count value is greater
         * than maxCount, which is initialized as 0, it updates the maxCount as current count and maxKey as the current count's
         * key.
         *
         * @return K type maxKey which is the maximum valued key.
         */
        public TKey Max()
        {
            var maxCount = 0;
            var maxKey = default(TKey);
            foreach (var entry in this.Keys)
            {
                var count = this[entry];
                if (count > maxCount)
                {
                    maxCount = count;
                    maxKey = entry;
                }
            }
            return maxKey;
        }

        public TKey Max(double threshold)
        {
            var maxCount = 0;
            var total = 0;
            var maxKey = default(TKey);
            foreach (var entry in this.Keys)
            {
                var count = this[entry];
                total += count;
                if (count > maxCount)
                {
                    maxCount = count;
                    maxKey = entry;
                }
            }
            return maxCount / (total + 0.0) > threshold ? maxKey : default(TKey);
        }
    }
}