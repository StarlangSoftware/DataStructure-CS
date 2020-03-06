namespace DataStructure.Cache
{
    public class CacheNode<TKey, TData>
    {
        private readonly TData _data;
        private readonly TKey _key;
        private CacheNode<TKey, TData> _previous;
        private CacheNode<TKey, TData> _next;

        /**
         * A constructor of {@link CacheNode} class which takes a key and a data as inputs and initializes private fields with these inputs.
         *
         * @param key  K type input for representing keys.
         * @param data T type input values represented by keys.
         */
        public CacheNode(TKey key, TData data)
        {
            this._key = key;
            this._data = data;
        }

        /**
         * Getter for data value.
         *
         * @return data value.
         */
        public TData GetData()
        {
            return _data;
        }

        /**
         * Getter for key value.
         *
         * @return key value.
         */
        public TKey GetKey()
        {
            return _key;
        }

        /**
         * Getter for the previous CacheNode.
         *
         * @return previous CacheNode.
         */
        public CacheNode<TKey, TData> GetPrevious()
        {
            return _previous;
        }

        /**
         * Getter for the next CacheNode.
         *
         * @return next CacheNode.
         */
        public CacheNode<TKey, TData> GetNext()
        {
            return _next;
        }

        /**
         * Setter for the previous CacheNode.
         *
         * @param previous CacheNode.
         */
        public void SetPrevious(CacheNode<TKey, TData> previous)
        {
            this._previous = previous;
        }

        /**
         * Setter for the next CacheNode.
         *
         * @param next CacheNode.
         */
        public void SetNext(CacheNode<TKey, TData> next)
        {
            this._next = next;
        }
    }
}