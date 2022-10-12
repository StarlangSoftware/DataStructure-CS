using System.Collections.Generic;

namespace DataStructure.Heap
{
    public class MaxHeap<T> : Heap<T>
    {
        public MaxHeap(int n, Comparer<T> comparator) : base(n, comparator)
        {
        }

        protected override int Compare(T data1, T data2)
        {
            return comparator.Compare(data1, data2);
        }
    }
}