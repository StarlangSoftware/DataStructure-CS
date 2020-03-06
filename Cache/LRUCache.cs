using System.Collections.Generic;

namespace DataStructure.Cache
{
    public class LRUCache<TKey, TData>
    {
        private int cacheSize;
        private Dictionary<TKey, CacheNode<TKey, TData>> map;
        private CacheLinkedList<TKey, TData> cache;

        /**
         * A constructor of {@link LRUCache} class which takes cacheSize as input. It creates new {@link CacheLinkedList} and
         * {@link HashMap}.
         *
         * @param cacheSize Integer input defining cache size.
         */
        public LRUCache(int cacheSize)
        {
            this.cacheSize = cacheSize;
            cache = new CacheLinkedList<TKey, TData>();
            map = new Dictionary<TKey, CacheNode<TKey, TData>>();
        }

        /**
         * The contains method takes a K type input key and returns true if the {@link HashMap} has the given key, false otherwise.
         *
         * @param key K type input key.
         * @return true if the {@link HashMap} has the given key, false otherwise.
         */
        public bool Contains(TKey key)
        {
            return map.ContainsKey(key);
        }

        /**
         * The get method takes K type input key and returns the least recently used value. First it checks whether the {@link HashMap}
         * has the given key, if so it gets the corresponding cacheNode. It removes that cacheNode from {@link java.util.LinkedList}
         * and adds it again to the beginning of the list since it is more likely to be used again. At the end, returns the
         * data value of that cacheNode.
         *
         * @param key K type input key.
         * @return data value if the {@link HashMap} has the given key, null otherwise.
         */
        public TData Get(TKey key)
        {
            if (map.ContainsKey(key))
            {
                var cacheNode = map[key];
                cache.Remove(cacheNode);
                cache.Add(cacheNode);
                return cacheNode.GetData();
            }
            else
            {
                return default(TData);
            }
        }

        /**
         * The add method take a key and a data as inputs. First it checks the size of the {@link HashMap}, if it is full (i.e
         * equal to the given cacheSize) then it removes the last cacheNode in the @link java.util.LinkedList}. If it has space for new entries,
         * it creates new cacheNode with given inputs and adds this cacheNode to the {@link java.util.LinkedList} and also puts
         * it to the {@link HashMap}.
         *
         * @param key  K type input.
         * @param data T type input
         */
        public void Add(TKey key, TData data)
        {
            if (map.Count == cacheSize)
            {
                var removed = cache.Remove();
                map.Remove(removed.GetKey());
            }
            var cacheNode = new CacheNode<TKey, TData>(key, data);
            cache.Add(cacheNode);
            map[key] = cacheNode;
        }
    }
}