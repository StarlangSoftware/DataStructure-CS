namespace DataStructure.Cache
{
    public class CacheLinkedList<TKey, TData>
    {
        private CacheNode<TKey, TData> _head;
        private CacheNode<TKey, TData> _tail;

        /**
         * The remove method takes a CacheNode type input cacheNode. If cacheNode has a previous node, then assigns cacheNode's
         * next node as previous node's next node. If cacheNode has not got a previous node, then assigns its next node as head node.
         * Moreover, if cacheNode has a next node, then assigns cacheNode's previous node as next node's previous node; if not
         * assigns tail node's previous node as tail. By doing so it removes the cacheNode from doubly {@link java.util.LinkedList}.
         *
         * @param cacheNode {@link CacheNode} type input to remove.
         */
        public void Remove(CacheNode<TKey, TData> cacheNode)
        {
            var previous = cacheNode.GetPrevious();
            var next = cacheNode.GetNext();
            if (previous != null)
            {
                previous.SetNext(next);
            }
            else
            {
                _head = _head.GetNext();
            }

            if (next != null)
            {
                next.SetPrevious(previous);
            }
            else
            {
                _tail = _tail.GetPrevious();
            }
        }

        /**
         * The add method adds given {@link CacheNode} type input cacheNode to the beginning of the doubly {@link java.util.LinkedList}.
         * First it sets cacheNode's previous node as null and cacheNode's next node as head node. If head node is not null then it assigns
         * cacheNode's previous node as head node and if tail is null then it assigns cacheNode as tail.
         *
         * @param cacheNode {@link CacheNode} type input to add to the doubly {@link java.util.LinkedList}.
         */
        public void Add(CacheNode<TKey, TData> cacheNode)
        {
            cacheNode.SetPrevious(null);
            cacheNode.SetNext(_head);
            _head?.SetPrevious(cacheNode);
            _head = cacheNode;
            if (_tail == null)
            {
                _tail = cacheNode;
            }
        }

        /**
         * The remove method removes the last element of the doubly {@link java.util.LinkedList}. It assigns the previous node of
         * current tail as new tail. If the current tail is null then it assigns head to null.
         *
         * @return {@link CacheNode} type output tail which is removed from doubly {@link java.util.LinkedList}.
         */
        public CacheNode<TKey, TData> Remove()
        {
            var removed = _tail;
            _tail = _tail.GetPrevious();
            if (_tail == null)
            {
                _head = null;
            }

            return removed;
        }
    }
}