namespace DataStructure.Heap
{
    public class HeapNode<T>
    {
        private T _data;
        public HeapNode(){
        }

        public HeapNode(T data){
            _data = data;
        }

        public T GetData(){
            return _data;
        }
    }
}