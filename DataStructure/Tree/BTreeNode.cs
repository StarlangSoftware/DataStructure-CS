using System.Collections.Generic;

namespace DataStructure.Tree
{
    public class BTreeNode<T>
    {
        internal readonly T[] k;
        internal int m;
        internal int d;
        internal bool leaf;
        internal BTreeNode<T>[] children;

        /**
         * <summary>Constructor of the B+ Tree node. By default, it is a leaf node. Initializes the attributes.</summary>
         * <param name="d">d in d-ary tree.</param>
         */
        public BTreeNode(int d)
        {
            m = 0;
            this.d = d;
            leaf = true;
            k = new T[2 * d + 1];
            children = new BTreeNode<T>[2 * d + 1];
        }

        /**
         * <summary>Another constructor of a B+ Tree node. By default, it is not a leaf node. Adds two children.</summary>
         * <param name="d">d in d-ary tree.</param>
         * <param name="firstChild">First child of the root node.</param>
         * <param name="secondChild">Second child of the root node.</param>
         * <param name="newK">First value in the node.</param>
         */
        public BTreeNode(int d, BTreeNode<T> firstChild, BTreeNode<T> secondChild, T newK) : this(d)
        {
            leaf = false;
            m = 1;
            children[0] = firstChild;
            children[1] = secondChild;
            k[0] = newK;
        }

        /**
         * <summary>Searches the position of value in the list K. If the searched value is larger than the last value of node, we
         * need to continue the search with the rightmost child. If the searched value is smaller than the i. value of node,
         * we need to continue the search with the i. child.</summary>
         * <param name="value">Searched value</param>
         * <param name="comparator">Comparator function which compares two elements.</param>
         * <returns>The position of searched value in array K.</returns>
         */
        public int Position(T value, Comparer<T> comparator)
        {
            if (m == 0)
            {
                return 0;
            }

            if (comparator.Compare(value, k[m - 1]) > 0)
            {
                return m;
            }
            else
            {
                for (var i = 0; i < m; i++)
                {
                    if (comparator.Compare(value, k[i]) <= 0)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        /**
         * <summary>Add the new value insertedK to the array K into the calculated position index.</summary>
         * <param name="index">Place to insert new value</param>
         * <param name="insertedK">New value to be inserted.</param>
         */
        private void InsertIntoK(int index, T insertedK)
        {
            for (var i = m; i > index; i--)
            {
                k[i] = k[i - 1];
            }

            k[index] = insertedK;
        }

        /**
         * <summary>Transfers the last d values of the current node to the newNode.</summary>
         * <param name="newNode">New node.</param>
         */
        private void MoveHalfOfTheKToNewNode(BTreeNode<T> newNode)
        {
            for (var i = 0; i < d; i++)
            {
                newNode.k[i] = k[i + d + 1];
                k[i + d + 1] = default;
            }

            newNode.m = d;
        }

        /**
         * <summary>Transfers the last d links of the current node to the newNode.</summary>
         * <param name="newNode">New node.</param>
         */
        private void MoveHalfOfTheChildrenToNewNode(BTreeNode<T> newNode)
        {
            for (var i = 0; i < d; i++)
            {
                newNode.children[i] = children[i + d + 1];
                children[i + d + 1] = null;
            }
        }

        /**
         * <summary>Transfers the last d values and the last d links of the current node to the newNode.</summary>
         * <param name="newNode">New node.</param>
         */
        private void MoveHalfOfTheElementsToNewNode(BTreeNode<T> newNode)
        {
            MoveHalfOfTheKToNewNode(newNode);
            MoveHalfOfTheChildrenToNewNode(newNode);
        }

        /**
         * <summary>First the function position is used to determine the node or the subtree to which the new node will be added.
         * If this subtree is a leaf node, we call the function insertLeaf that will add the value to a leaf node. If this
         * subtree is not a leaf node the function calls itself with the determined subtree. Both insertNode and insertLeaf
         * functions, if adding a new value/node to that node/subtree necessitates a new child node to be added to the
         * parent node, they will both return the new added node and the node obtained by dividing the original node. If
         * there is not such a restructuring, these functions will return null. If we add a new child node to the parent
         * node, first we open a space for that child node in the value array K, then we add this new node to the array K.
         * After adding there are two possibilities:
         * <ul>
         *     <li>After inserting the new child node, the current node did not exceed its capacity. In this case, we open
         *     space for the link, which points to the new node, in the array children and place that link inside of this
         *     array.</li>
         *     <li>After inserting the new child node, the current node exceed its capacity. In this case, we need to create
         *     newNode, transfer the last d values and the last d links of the current node to the newNode. As a last case,
         *     if the divided node is the root node, we need to create a new root node and the first child of this new root
         *     node will be b, and the second child of the new root node will be newNode.</li>
         * </ul></summary>
         * <param name="value">Value to be inserted into B+ tree.</param>
         * <param name="comparator">Comparator function to compare two elements.</param>
         * <param name="isRoot">If true, value is inserted as a root node, otherwise false.</param>
         * <returns>If inserted node results in a creation of a node, the function returns that node, otherwise null.</returns>
         */
        public BTreeNode<T> InsertNode(T value, Comparer<T> comparator, bool isRoot)
        {
            BTreeNode<T> s, newNode;
            int child;
            child = Position(value, comparator);
            if (!children[child].leaf)
            {
                s = children[child].InsertNode(value, comparator, false);
            }
            else
            {
                s = children[child].InsertLeaf(value, comparator);
            }

            if (s == null)
            {
                return null;
            }

            InsertIntoK(child, children[child].k[d]);
            children[child].k[d] = default;
            if (m < 2 * d)
            {
                children[child + 1] = s;
                m++;
                return null;
            }
            else
            {
                newNode = new BTreeNode<T>(d);
                newNode.leaf = false;
                MoveHalfOfTheElementsToNewNode(newNode);
                newNode.children[d] = s;
                m = d;
                if (isRoot)
                {
                    var a = new BTreeNode<T>(d, this, newNode, k[d]);
                    k[d] = default;
                    return a;
                }
                else
                {
                    return newNode;
                }
            }
        }

        /**
         * <summary>First the function position is used to determine the position where the new value will be placed Then we open a
         * space for that value in the value array K, then we add this new value to the array K into the calculated
         * position. At this stage there are again two possibilities:
         * <ul>
         *     <li>After inserting the new value, the current leaf node did not exceed its capacity. The function returns
         *     null.</li>
         *     <li>After inserting the new value, the current leaf node exceed its capacity. In this case, we need to create
         *     the newNode, and transfer the last d values of node b to this newNode.</li>
         * </ul></summary>
         * <param name="value">Value to be inserted into B+ tree.</param>
         * <param name="comparator">Comparator function to compare two elements.</param>
         * <returns>If inserted node results in a creation of a node, the function returns that node, otherwise null.</returns>
         */
        public BTreeNode<T> InsertLeaf(T value, Comparer<T> comparator)
        {
            int child;
            BTreeNode<T> newNode;
            child = Position(value, comparator);
            InsertIntoK(child, value);
            if (m < 2 * d)
            {
                m++;
                return null;
            }
            else
            {
                newNode = new BTreeNode<T>(d);
                MoveHalfOfTheKToNewNode(newNode);
                m = d;
                return newNode;
            }
        }
    }
}