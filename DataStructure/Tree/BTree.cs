using System.Collections.Generic;

namespace DataStructure.Tree
{
    public class BTree<T>
    {
        BTreeNode<T> root = null;
        Comparer<T> comparator;
        int d;

        public BTree(int d, Comparer<T> comparator){
            this.comparator = comparator;
            this.d = d;
        }

        public BTreeNode<T> Search(T value){
            int child;
            BTreeNode<T> b;
            b = root;
            while (!b.leaf){
                child = b.Position(value, comparator);
                if (child < b.m && b.K[child].Equals(value)){
                    return b;
                }
                b = b.children[child];
            }
            child = b.Position(value, comparator);
            if (child < b.m && b.K[child].Equals(value)){
                return b;
            }
            return null;
        }

        public void Insert(T data){
            BTreeNode<T> s;
            if (root == null){
                root = new BTreeNode<T>(d);
            }
            if (root.leaf){
                s = root.InsertLeaf(data, comparator);
                if (s != null){
                    BTreeNode<T> tmp = root;
                    root = new BTreeNode<T>(d, tmp, s, tmp.K[d]);
                    tmp.K[d] = default;
                }
            } else {
                s = root.InsertNode(data, comparator, true);
                if (s != null){
                    root = s;
                }
            }
        }

    }
}