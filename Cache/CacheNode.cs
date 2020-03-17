namespace DataStructure.Cache
{
    public class CacheNode<TKey, TData>
    {
        private readonly TData _data;
        private readonly TKey _key;
        private CacheNode<TKey, TData> _previous;
        private CacheNode<TKey, TData> _next;

        ///
        ///<summary>A constructor of {@link CacheNode} class which takes a key and a data as inputs and initializes
        /// private fields with these inputs.</summary>
        ///
        ///<param name="key">  K type input for representing keys.</param>
        ///<param name="data"> T type input values represented by keys.</param>
        ///
        public CacheNode(TKey key, TData data)
        {
            this._key = key;
            this._data = data;
        }

        ///
        ///<summary>Getter for data value.</summary>
        ///
        ///<returns>data value.</returns>
        ///
        public TData GetData()
        {
            return _data;
        }

        ///
        ///<summary>Getter for key value.</summary>
        ///
        ///<returns>key value.</returns>
        ///
        public TKey GetKey()
        {
            return _key;
        }

        ///
        ///<summary>Getter for the previous CacheNode.</summary>
        ///
        ///<returns>previous CacheNode.</returns>
        ///
        public CacheNode<TKey, TData> GetPrevious()
        {
            return _previous;
        }

        ///
        ///<summary>Getter for the next CacheNode.</summary>
        ///
        ///<returns>next CacheNode.</returns>
        ///
        public CacheNode<TKey, TData> GetNext()
        {
            return _next;
        }

        ///
        ///<summary>Setter for the previous CacheNode.</summary>
        ///
        ///<param name="previous"> CacheNode.</param>
        ///
        public void SetPrevious(CacheNode<TKey, TData> previous)
        {
            this._previous = previous;
        }

        ///
        ///<summary>Setter for the next CacheNode.</summary>
        ///
        ///<param name="next"> CacheNode.</param>
        ///
        public void SetNext(CacheNode<TKey, TData> next)
        {
            this._next = next;
        }
    }
}