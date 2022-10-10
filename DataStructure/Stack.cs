using System.Collections.Generic;

namespace DataStructure
{
    public class Stack<T>
    {
        private readonly List<T> _list = new List<T>();

        public void Push(T item){
            _list.Add(item);
        }

        public T Pop(){
            if (_list.Count > 0)
            {
                var item = _list[_list.Count - 1]; 
                _list.RemoveAt(_list.Count - 1);
                return item;
            }
            else
            {
                return default;
            }
        }

        public bool IsEmpty(){
            return _list.Count == 0;
        }

    }
}