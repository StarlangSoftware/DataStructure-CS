using System.Collections.Generic;

namespace DataStructure
{
    /**
     * <summary>Stack is a list data structure consisting of many elements. There are two types of operations defined for the
     * elements of the stack: Adding an element to the stack (push) and removing an element from the stack (pop). In a
     * stack, to be popped element is always the last pushed element. Also, when an element is pushed on to the stack, it
     * is placed on top of the stack (at the end of the list).</summary>
     * <param name="T">Type of the data stored in the heap node.</param>
     */
    public class Stack<T>
    {
        private readonly List<T> _list = new List<T>();

        /**
         * <summary>When we push an element on top of the stack, we only need to increase the field top by 1 and place the new
         * element on this new position. If the stack is full before this push operation, we can not push.</summary>
         * <param name="item">Item to insert.</param>
         */
        public void Push(T item){
            _list.Add(item);
        }

        /**
         * <summary>When we remove an element from the stack (the function also returns that removed element), we need to be careful
         * if the stack was empty or not. If the stack is not empty, the topmost element of the stack is returned and the
         * field top is decreased by 1. If the stack is empty, the function will return null.</summary>
         * <returns>The removed element</returns>
         */
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

        /**
         * <summary>The function checks whether an array-implemented stack is empty or not. The function returns true if the stack is
         * empty, false otherwise.</summary>
         * <returns>True if the stack is empty, false otherwise.</returns>
         */
        public bool IsEmpty(){
            return _list.Count == 0;
        }

    }
}