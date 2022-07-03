namespace DataStructure.Tree
{
    public class TreeNode<T>
    {
        internal T data;
        internal TreeNode<T> left = null;
        internal TreeNode<T> right = null;

        public TreeNode()
        {
            
        }
        public TreeNode(T data){
            this.data = data;
        }
    }
}