using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractCollections
{
    class ADTStack<T>
    {
        private T[] _array;
        private int _index;
        private const int GrowsOnDemand = 2;

        public ADTStack(int length)
        {
            _array = new T[length]; ;
            _index = 0;
        }
        public void Push(T item)
        {
            try
            {
                _array[_index] = item;
                _index++;
            }
            catch
            {
                T[] newArr = new T[_index * GrowsOnDemand];
                for (int i = 0; i < _array.Length; i++)
                {
                    newArr[i] = _array[i];
                }
                _array = newArr;
                _array[_index] = item;
                _index++;
            }

        }
        public T Pop()
        {
            try
            {
                T item = _array[_index - 1];
                _index--;
                return item;
            }
            catch
            {
                throw new ApplicationException("Out Of Range");
            }


        }
        public T Top()
        {
            try
            {
                return _array[_index - 1];
            }
            catch
            {
                throw new ApplicationException("Out Of Range");
             }

         }
        public bool IsEmpty()
        {
            return _index == 0;

        }
        public void Print()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.WriteLine(_array[i]);
            }
        }


    }
}
