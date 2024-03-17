using System;
using System.Collections.Generic;

namespace DataStructure.Tree
{
    public class AvlTree<T> : Tree<T>
    {
        public AvlTree(Comparer<T> comparator) : base(comparator)
        {
        }

        public int Height(AvlTreeNode<T> d)
        {
            if (d == null)
            {
                return 0;
            }
            else
            {
                return d.height;
            }
        }

        private AvlTreeNode<T> RotateLeft(AvlTreeNode<T> k2)
        {
            var k1 = (AvlTreeNode<T>)k2.left;
            k2.left = k1.right;
            k1.right = k2;
            k2.height = Math.Max(Height((AvlTreeNode<T>)k2.left), Height((AvlTreeNode<T>)k2.right)) + 1;
            k1.height = Math.Max(Height((AvlTreeNode<T>)k1.left), ((AvlTreeNode<T>)k1.right).height) + 1;
            return k1;
        }

        private AvlTreeNode<T> RotateRight(AvlTreeNode<T> k1)
        {
            var k2 = (AvlTreeNode<T>)k1.right;
            k1.right = k2.left;
            k2.left = k1;
            k2.height = Math.Max(((AvlTreeNode<T>)k2.left).height, Height((AvlTreeNode<T>)k2.right)) + 1;
            k1.height = Math.Max(Height((AvlTreeNode<T>)k1.left), Height((AvlTreeNode<T>)k1.right)) + 1;
            return k2;
        }

        private AvlTreeNode<T> DoubleRotateLeft(AvlTreeNode<T> k3)
        {
            k3.left = RotateRight((AvlTreeNode<T>)k3.left);
            return RotateLeft(k3);
        }

        private AvlTreeNode<T> DoubleRotateRight(AvlTreeNode<T> k1)
        {
            k1.right = RotateLeft((AvlTreeNode<T>)k1.right);
            return RotateRight(k1);
        }

        public void Insert(AvlTreeNode<T> node)
        {
            int left = 1, right = 2;
            AvlTreeNode<T> y = null, x = (AvlTreeNode<T>)root, t;
            int dir1 = 0, dir2 = 0;
            var c = new Stack<AvlTreeNode<T>>();
            while (x != null)
            {
                y = x;
                c.Push(y);
                dir1 = dir2;
                if (comparator.Compare(node.data, x.data) < 0)
                {
                    x = (AvlTreeNode<T>)x.left;
                    dir2 = left;
                }
                else
                {
                    x = (AvlTreeNode<T>)x.right;
                    dir2 = right;
                }
            }

            InsertChild(y, node);
            while (!c.IsEmpty())
            {
                x = c.Pop();
                x.height = Math.Max(Height((AvlTreeNode<T>)x.left), Height((AvlTreeNode<T>)x.right)) + 1;
                if (Math.Abs(Height((AvlTreeNode<T>)x.left) - Height((AvlTreeNode<T>)x.right)) == 2)
                {
                    if (dir1 == left)
                    {
                        if (dir2 == left)
                        {
                            t = RotateLeft(x);
                        }
                        else
                        {
                            t = DoubleRotateLeft(x);
                        }
                    }
                    else
                    {
                        if (dir2 == left)
                        {
                            t = DoubleRotateRight(x);
                        }
                        else
                        {
                            t = RotateRight(x);
                        }
                    }

                    y = c.Pop();
                    InsertChild(y, t);
                    break;
                }
            }
        }

        public new void Insert(T item)
        {
            Insert(new AvlTreeNode<T>(item));
        }
    }
}