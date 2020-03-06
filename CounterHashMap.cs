using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{
    public class CounterHashMap<TKey> : Dictionary<TKey, int>
    {

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
        public void PutNTimes(TKey key, int n)
        {
            if (ContainsKey(key))
            {
                Add(key, this[key] + n);
            }
            else
            {
                Add(key, n);
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

        /**
         * The max method takes a threshold as input and loops through the mappings contained in this map. It accumulates the
         * count values and if the current entry's count value is greater than maxCount, which is initialized as 0,
         * it updates the maxCount as current count and maxKey as the current count's key.
         *
         * At the end of the loop, if the ratio of maxCount/total is greater than the given threshold it returns maxKey, else null.
         *
         * @param threshold double value.
         * @return K type maxKey if greater than the given threshold, null otherwise.
         */
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

        /**
         * The add method adds value of each key of toBeAdded to the current counterHashMap.
         *
         * @param toBeAdded CounterHashMap to be added to this counterHashMap.
         */
        public void Add(Dictionary<TKey, int> toBeAdded)
        {
            foreach (var value in toBeAdded.Keys)
            {
                PutNTimes(value, toBeAdded[value]);
            }
        }

        /**
         * The topN method takes an integer N as inout. It creates an {@link ArrayList} result and loops through the the
         * mappings contained in this map and adds each entry to the result {@link ArrayList}. Then sort this {@link ArrayList}
         * according to their values and returns an {@link ArrayList} which is a sublist of result with N elements.
         *
         * @param N Integer value for defining size of the sublist.
         * @return a sublist of N element.
         */
        public ArrayList TopN(int n)
        {
            var result = new ArrayList();
            foreach (var entry in this)
            {
                result.Add(entry);
            }
            result.Sort();
            return result.GetRange(0, n);
        }

        /**
         * The toString method loops through the mappings contained in this map and returns the string of each entry's key and value.
         *
         * @return String of the each entry's key and value.
         */
        public override string ToString()
        {
            return Keys.Aggregate("", (current, entry) => current + (entry.ToString() + " " + this[entry] + "\n"));
        }
    }
}