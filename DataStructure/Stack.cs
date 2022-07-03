using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class Stack<T>
    {
        private List<T> list = new List<T>();

        public Stack(){

        }

        public void Push(T item){
            list.Add(item);
        }

        public T Pop(){
            if (list.Count > 0)
            {
                T item = list[list.Count - 1]; 
                list.RemoveAt(list.Count - 1);
                return item;
            }
            else
            {
                return default(T);
            }
        }

        public Boolean IsEmpty(){
            return list.Count == 0;
        }

    }
}