namespace DataStructure.Heap
{
    public class HeapNode<T>
    {
        private T _data;
        public HeapNode(){
        }
        
        /**
         * <summary>Constructor of HeapNode.</summary>
         * <param name="data">Data to be stored in the heap node.</param>
         */
        public HeapNode(T data){
            _data = data;
        }

        /**
         * <summary>Mutator of the data field</summary>
         * <returns>Data</returns>
         */
        public T GetData(){
            return _data;
        }
    }
}