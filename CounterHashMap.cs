using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{
    public class CounterHashMap<TKey> : Dictionary<TKey, int>
    {
        ///
        ///<summary>The put method takes a K type input. If this map contains a mapping for the key, it puts this key
        /// after incrementing its value by one. If his map does not contain a mapping, then it directly puts key with
        /// the value of 1.</summary>
        ///
        ///<param name="key"> to put.</param>
        ///
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

        ///
        ///<summary>The putNTimes method takes a K and an integer N as inputs. If this map contains a mapping for the
        /// key, it puts this key after incrementing its value by N. If his map does not contain a mapping, then it
        /// directly puts key with the value of N.</summary>
        ///
        ///<param name="key"> to put.</param>
        ///<param name="n">   to increment value.</param>
        ///
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

        ///
        ///<summary>The count method takes a K as input, if this map contains a mapping for the key, it returns the value
        /// corresponding this key, 0 otherwise.</summary>
        ///
        ///<param name="key"> to get value.</param>
        ///<returns>the value corresponding given key, 0 if it is not mapped.</returns>
        ///
        public int Count(TKey key)
        {
            return ContainsKey(key) ? this[key] : 0;
        }

        ///
        ///<summary>The sumOfCounts method loops through the values contained in this map and accumulates the counts of
        /// this values.</summary>
        ///
        ///<returns>accumulated counts.</returns>
        ///
        public int SumOfCounts()
        {
            return this.Values.Sum();
        }

        ///
        ///<summary>The max method loops through the mappings contained in this map and if the current entry's count
        /// value is greater than maxCount, which is initialized as 0, it updates the maxCount as current count and
        /// maxKey as the current count's key.</summary>
        ///
        ///<returns>K type maxKey which is the maximum valued key.</returns>
        ///
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

        ///
        /// <summary>The max method takes a threshold as input and loops through the mappings contained in this map.
        /// It accumulates the count values and if the current entry's count value is greater than maxCount, which is
        /// initialized as 0, it updates the maxCount as current count and maxKey as the current count's key. At the end
        /// of the loop, if the ratio of maxCount/total is greater than the given threshold it returns maxKey, else
        /// null.</summary>
        ///
        ///<param name="threshold"> double value.</param>
        ///<returns>K type maxKey if greater than the given threshold, null otherwise.</returns>
        ///
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

        ///
        ///<summary>The add method adds value of each key of toBeAdded to the current counterHashMap.</summary>
        ///
        ///<param name="toBeAdded"> CounterHashMap to be added to this counterHashMap.</param>
        ///
        public void Add(Dictionary<TKey, int> toBeAdded)
        {
            foreach (var value in toBeAdded.Keys)
            {
                PutNTimes(value, toBeAdded[value]);
            }
        }

        ///
        ///<summary>The topN method takes an integer N as inout. It creates an {@link ArrayList} result and loops through
        /// the mappings contained in this map and adds each entry to the result {@link ArrayList}. Then sort this
        /// {@link ArrayList} according to their values and returns an {@link ArrayList} which is a sublist of result
        /// with N elements.</summary>
        ///
        ///<param name="n"> Integer value for defining size of the sublist.</param>
        ///<returns>a sublist of N element.</returns>
        ///
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

        ///
        ///<summary>The toString method loops through the mappings contained in this map and returns the string of each
        /// entry's key and value.</summary>
        ///
        ///<returns>String of the each entry's key and value.</returns>
        ///
        public override string ToString()
        {
            return Keys.Aggregate("", (current, entry) => current + (entry.ToString() + " " + this[entry] + "\n"));
        }
    }
}