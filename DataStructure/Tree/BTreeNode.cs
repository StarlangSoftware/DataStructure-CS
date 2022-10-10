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

        public BTreeNode(int d)
        {
            m = 0;
            this.d = d;
            leaf = true;
            k = new T[2 * d + 1];
            children = new BTreeNode<T>[2 * d + 1];
        }

        public BTreeNode(int d, BTreeNode<T> firstChild, BTreeNode<T> secondChild, T newK) : this(d)
        {
            leaf = false;
            m = 1;
            children[0] = firstChild;
            children[1] = secondChild;
            k[0] = newK;
        }

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

        private void InsertIntoK(int index, T insertedK)
        {
            for (var i = m; i > index; i--)
            {
                k[i] = k[i - 1];
            }

            k[index] = insertedK;
        }

        private void MoveHalfOfTheKToNewNode(BTreeNode<T> newNode)
        {
            for (var i = 0; i < d; i++)
            {
                newNode.k[i] = k[i + d + 1];
                k[i + d + 1] = default;
            }

            newNode.m = d;
        }

        private void MoveHalfOfTheChildrenToNewNode(BTreeNode<T> newNode)
        {
            for (var i = 0; i < d; i++)
            {
                newNode.children[i] = children[i + d + 1];
                children[i + d + 1] = null;
            }
        }

        private void MoveHalfOfTheElementsToNewNode(BTreeNode<T> newNode)
        {
            MoveHalfOfTheKToNewNode(newNode);
            MoveHalfOfTheChildrenToNewNode(newNode);
        }

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