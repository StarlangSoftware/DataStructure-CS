using System.Collections.Generic;

namespace DataStructure.Heap
{
    /**
     * <summary>
     * <p>The heap data structure is a binary tree structure consisting of N elements. It shows the basic properties of the
     * binary tree data structure. The heap has a root node and each node of it has at most two child nodes
     * (left and right). The root node of the tree is shown at the top, and its branches grow not to up but to down manner.
     * </p>
     *
     * <p>In a heap, if the maximum element is in the root node and all nodes are smaller than its descendants, then this heap
     * is called max-heap, if the minimum element is in the root node and all nodes are larger than its descendants, then
     * this heap is called min-heap.</p></summary>
     * <param name="T">Type of the data stored in the heap node.</param>
     */
    public abstract class Heap<T>
    {
        private HeapNode<T>[] _array;
        protected Comparer<T> comparator;
        private int _count;
        private int _n;

        /**
         * <summary>Constructor of the heap. According to the comparator, the heap could be min or max heap.</summary>
         * <param name="N"> Maximum number of elements in the heap.</param>
         * <param name="comparator">Comparator function to compare two elements.</param>
         */
        public Heap(int n, Comparer<T> comparator)
        {
            _array = new HeapNode<T>[n];
            _count = 0;
            _n = n;
            this.comparator = comparator;
        }

        protected abstract int Compare(T data1, T data2);

        /**
         * <summary>Checks if the heap is empty or not.</summary>
         * <returns>True if the heap is empty, false otherwise.</returns>
         */
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /**
         * <summary>Swaps two heap nodes in the heap given their indexes.</summary>
         * <param name="index1">Index of the first node to swap.</param>
         * <param name="index2">Index of the second node to swap.</param>
         */
        private void SwapNode(int index1, int index2)
        {
            HeapNode<T> tmp = _array[index1];
            _array[index1] = _array[index2];
            _array[index2] = tmp;
        }

        /**
         * <summary>The function percolates down from a node of the tree to restore the max-heap property. Left or right children are
         * checked, if one of them is larger than the current element of the heap, the iteration continues. The iteration is,
         * determining the largest one of the node's children and switching that node's value with the current node's value.
         * We need to check if current node's left and right children exist or not. These checks are done with for the left
         * child and with for the right child.</summary>
         * <param name="no">Index of the starting node to restore the max-heap property.</param>
         */
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

        /**
         * <summary>The function percolates up from a node of the tree to restore the max-heap property. As long as the max-heap
         * property is corrupted, the parent and its child switch their values. We need to pay attention that, the
         * calculated index of the parent must be a valid number. In other words, while going upper levels,we need to see
         * that we can not go up if we are at the root of the tree.</summary>
         * <param name="no">Index of the starting node to restore the max-heap property.</param>
         */
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

        /**
         * <summary>The function will return the first element, therefore the first element is stored in the variable, and the first
         * element of the heap is set to the last element of the heap. After that, in order to restore the max-heap
         * property, we percolate down the tree using the function. As a last step, the number of element in the heap is
         * decremented by one.</summary>
         * <returns>The first element</returns>
         */
        public T Delete()
        {
            HeapNode<T> tmp;
            tmp = _array[0];
            _array[0] = _array[_count - 1];
            PercolateDown(0);
            _count--;
            return tmp.GetData();
        }

        /**
         * <summary>The insertion of a new element to the heap, proceeds from the leaf nodes to the root node. First the new element
         * is added to the end of the heap, then as long as the max-heap property is corrupted, the new element switches
         * place with its parent.</summary>
         * <param name="data">New element to be inserted.</param>
         */
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