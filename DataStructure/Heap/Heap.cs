using System.Collections.Generic;

namespace DataStructure.Heap
{
    public abstract class Heap<T>
    {
        private HeapNode<T>[] _array;
        protected Comparer<T> comparator;
        private int _count;
        private int _n;

        public Heap(int n, Comparer<T> comparator)
        {
            _array = new HeapNode<T>[n];
            _count = 0;
            _n = n;
            this.comparator = comparator;
        }

        protected abstract int Compare(T data1, T data2);

        public bool IsEmpty()
        {
            return _count == 0;
        }

        private void SwapNode(int index1, int index2)
        {
            HeapNode<T> tmp = _array[index1];
            _array[index1] = _array[index2];
            _array[index2] = tmp;
        }

        private void PercolateDown(int no)
        {
            var left = 2 * no + 1;
            var right = 2 * no + 2;
            while ((left < _count && Compare(_array[no].GetData(), _array[left].GetData()) < 0) ||
                   (right < _count && Compare(_array[no].GetData(), _array[right].GetData()) < 0))
            {
                if (right >= _count || Compare(_array[left].GetData(), _array[right].GetData()) > 0)
                {
                    SwapNode(no, left);
                    no = left;
                }
                else
                {
                    SwapNode(no, right);
                    no = right;
                }

                left = 2 * no + 1;
                right = 2 * no + 2;
            }
        }

        private void PercolateUp(int no)
        {
            var parent = (no - 1) / 2;
            while (parent >= 0 && Compare(_array[parent].GetData(), _array[no].GetData()) < 0)
            {
                SwapNode(parent, no);
                no = parent;
                parent = (no - 1) / 2;
            }
        }

        public T Delete()
        {
            HeapNode<T> tmp;
            tmp = _array[0];
            _array[0] = _array[_count - 1];
            PercolateDown(0);
            _count--;
            return tmp.GetData();
        }

        public void Insert(T data)
        {
            if (_count < _n)
            {
                _count++;
            }
            _array[_count - 1] = new HeapNode<T>(data);
            PercolateUp(_count - 1);
        }
    }
}