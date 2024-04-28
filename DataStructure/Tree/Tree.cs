using System.Collections.Generic;

namespace DataStructure.Tree
{
    /**
     * <summary>Tree structure is also a non-linear data structure. Different from the tree structure we see in the nature, the
     * tree data structure has its root on top and develops its branches down.</summary>
     * <param name="T">Type of the data stored in the tree node.</param>
     */
    public class Tree<T>
    {
        protected TreeNode<T> root;
        protected readonly Comparer<T> comparator;

        public Tree()
        {
            
        }
        /**
         * <summary>Constructor of the tree. According to the comparator, the tree could contain any object.</summary>
         * <param name="comparator">Comparator function to compare two elements.</param>
         */
        public Tree(Comparer<T> comparator){
            this.comparator = comparator;
        }

        /**
         * <summary>The search starts from the root node, and we represent the node, with which we compare the searched value, with
         * d. If the searched value is equal to the value of the current node, we have found the node we search for, the
         * function will return that node. If the searched value is smaller than the value of the current node , the number
         * we search for must be on the left subtree of the current node, therefore the new current node must be the left
         * child of the current node. As the last case, if the searched value is larger than the value of the current node,
         * the number we search for must be on the right subtree of the current node, therefore the new current node must be
         * the right child of the current node. If this search continues until the leaf nodes of the tree and we can't find
         * the node we search for, node d will be null and the function will return null.</summary>
         * <param name="value">Searched value</param>
         * <returns>If the value exists in the tree, the function returns the node that contains the node. Otherwise, it
         * returns null.</returns>
         */
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

        /**
         * <summary>Inserts a child to its parent as left or right child.</summary>
         * <param name="parent">New parent of the child node.</param>
         * <param name="child">Child node.</param>
         */
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

        /**
         * <summary>In order to add a new node into a binary search tree, we need to first find out the place where we will insert
         * the new node. For this, we start from the root node and traverse the tree down. At each step, we compare the
         * value of the new node with the value of the current node. If the value of the new node is smaller than the value
         * of the current node, the new node will be inserted into the left subtree of the current node. To accomplish this,
         * we continue the process with the left child of the current node. If the situation is reverse, that is, if the
         * value of the new node is larger than the value of the current node, the new node will be inserted into the right
         * subtree of the current node. In this case, we continue the process with the right child of the current node.</summary>
         * <param name="node">Node to be inserted.</param>
         */
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