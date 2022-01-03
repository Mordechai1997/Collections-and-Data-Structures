using System;


namespace AbstractCollections
{
    class ADTQueue<T>
    {
        private T[] _arr;
        private int _head;
        private int _tail;
        private int _size;
        public ADTQueue(int langth)
        {
            _arr = new T [langth];
            _head = -1;
            _tail = 0;
            _size = 0;
        }
        public void Enqueue(T item)
        {

            if (_size == _arr.Length)
            {
                throw new Exception("Out of the middle");
            }
            _arr[_tail] = item;
            _tail = (_tail + 1) % _arr.Length;
            if (_head == -1)
            {
                _head = 0;
            }
            _size++;

        }
        public T Dequeue()
        {
           

            if ( _head == -1 || _size==0)// the array is empty 
            {
                throw new Exception("Out of the middle");
            }
           
            T temp = _arr[_head];
            _head = (_head + 1) % _arr.Length;

            _size--;

            return temp;

        }
        public bool IsEmpty()
        {
            return _size==0;
            
        }
        public void PrintQueue()
        {
            int index = _head;
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine(_arr[index]);
                index = (index + 1) % _arr.Length;
            }

        }
    }
}
