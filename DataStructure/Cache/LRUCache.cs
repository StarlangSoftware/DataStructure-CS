using System.Collections.Generic;

namespace DataStructure.Cache
{
    public class LRUCache<TKey, TData>
    {
        private readonly int _cacheSize;
        private readonly Dictionary<TKey, CacheNode<TKey, TData>> _map;
        private readonly CacheLinkedList<TKey, TData> _cache;

        ///
        ///<summary>A constructor of {@link LRUCache} class which takes cacheSize as input. It creates new
        /// {@link CacheLinkedList} and {@link HashMap}.</summary>
        ///
        ///<param name="cacheSize"> Integer input defining cache size.</param>
        ///
        public LRUCache(int cacheSize)
        {
            _cacheSize = cacheSize;
            _cache = new CacheLinkedList<TKey, TData>();
            _map = new Dictionary<TKey, CacheNode<TKey, TData>>();
        }

        ///
        ///<summary>The contains method takes a K type input key and returns true if the {@link HashMap} has the given
        /// key, false otherwise.</summary>
        ///
        ///<param name="key"> K type input key.</param>
        ///<returns>true if the {@link HashMap} has the given key, false otherwise.</returns>
        ///
        public bool Contains(TKey key)
        {
            return _map.ContainsKey(key);
        }

        ///
        ///<summary>The get method takes K type input key and returns the least recently used value. First it checks
        /// whether the {@link HashMap} has the given key, if so it gets the corresponding cacheNode. It removes that
        /// cacheNode from {@link java.util.LinkedList} and adds it again to the beginning of the list since it is more
        /// likely to be used again. At the end, returns the data value of that cacheNode.</summary>
        ///
        ///<param name="key"> K type input key.</param>
        ///<returns>data value if the {@link HashMap} has the given key, null otherwise.</returns>
        ///
        public TData Get(TKey key)
        {
            if (_map.ContainsKey(key))
            {
                var cacheNode = _map[key];
                _cache.Remove(cacheNode);
                _cache.Add(cacheNode);
                return cacheNode.GetData();
            }
            else
            {
                return default;
            }
        }

        ///
        ///<summary>The add method take a key and a data as inputs. First it checks the size of the {@link HashMap}, if
        /// it is full (i.e equal to the given cacheSize) then it removes the last cacheNode in the
        /// {@link java.util.LinkedList}. If it has space for new entries, it creates new cacheNode with given inputs
        /// and adds this cacheNode to the {@link java.util.LinkedList} and also puts it to the
        /// {@link HashMap}.</summary>
        ///
        ///<param name="key">  K type input.</param>
        ///<param name="data"> T type input</param>
        ///
        public void Add(TKey key, TData data)
        {
            if (_map.Count == _cacheSize)
            {
                var removed = _cache.Remove();
                _map.Remove(removed.GetKey());
            }
            var cacheNode = new CacheNode<TKey, TData>(key, data);
            _cache.Add(cacheNode);
            _map[key] = cacheNode;
        }
    }
}