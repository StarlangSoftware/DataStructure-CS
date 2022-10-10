namespace DataStructure.Tree
{
    public class AvlTreeNode<T> : TreeNode<T>
    {
        internal int height;

        public AvlTreeNode(T data) : base(data){
            height = 1;
        }

    }
}