using System.Collections.Generic;

namespace DataStructure.Tree
{
    public class Tree<T>
    {
        protected TreeNode<T> root;
        protected readonly Comparer<T> comparator;

        public Tree()
        {
            
        }
        public Tree(Comparer<T> comparator){
            this.comparator = comparator;
        }

        public TreeNode<T> Search(T value){
            var d = root;
            while (d != null){
                if (comparator.Compare(d.data, value) == 0){
                    return d;
                } else {
                    if (comparator.Compare(d.data, value) > 0){
                        d = d.left;
                    } else {
                        d = d.right;
                    }
                }
            }
            return null;
        }

        protected void InsertChild(TreeNode<T> parent, TreeNode<T> child){
            if (parent == null) {
                root = child;
            } else {
                if (comparator.Compare(child.data, parent.data) < 0) {
                    parent.left = child;
                } else {
                    parent.right = child;
                }
            }
        }

        public void Insert(TreeNode<T> node){
            TreeNode<T> y = null;
            var x = root;
            while (x != null){
                y = x;
                if (comparator.Compare(node.data, x.data) < 0){
                    x = x.left;
                } else {
                    x = x.right;
                }
            }
            InsertChild(y, node);
        }

        public void Insert(T data){
            Insert(new TreeNode<T>(data));
        }

    }
}