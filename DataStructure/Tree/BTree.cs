using System.Collections.Generic;

namespace DataStructure.Tree
{
    public class BTree<T>
    {
        private BTreeNode<T> _root;
        private readonly Comparer<T> _comparator;
        private readonly int _d;

        public BTree(int d, Comparer<T> comparator){
            _comparator = comparator;
            _d = d;
        }

        public BTreeNode<T> Search(T value){
            int child;
            BTreeNode<T> b;
            b = _root;
            while (!b.leaf){
                child = b.Position(value, _comparator);
                if (child < b.m && b.k[child].Equals(value)){
                    return b;
                }
                b = b.children[child];
            }
            child = b.Position(value, _comparator);
            if (child < b.m && b.k[child].Equals(value)){
                return b;
            }
            return null;
        }

        public void Insert(T data){
            BTreeNode<T> s;
            if (_root == null){
                _root = new BTreeNode<T>(_d);
            }
            if (_root.leaf){
                s = _root.InsertLeaf(data, _comparator);
                if (s != null){
                    var tmp = _root;
                    _root = new BTreeNode<T>(_d, tmp, s, tmp.k[_d]);
                    tmp.k[_d] = default;
                }
            } else {
                s = _root.InsertNode(data, _comparator, true);
                if (s != null){
                    _root = s;
                }
            }
        }

    }
}