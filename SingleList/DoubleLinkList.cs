using System;


namespace AbstractCollections
{
    class DoubleLinkList<T>
    {

        public class Node
        {
            private T value;
            private Node next;
            private Node prev;

            public Node Prev { get => prev; set => prev = value; }
            public Node Next { get => next; set => next = value; }
            public T Value { get => value; set => this.value = value; }

            public Node(T item)
            {
                this.value = item;
                this.prev = null;
                this.next = null;
            }
            public Node(T item,  Node prev, Node next)
            {
                this.value = item;
                this.next = next;
                this.prev = prev;
            }


        }

        private Node _head;
        private Node _tail;

        public DoubleLinkList()
        {
            _head = _tail = null;

        }

        public void ListPushHead(T item)
        {
            if (_head == null)
            {
                _tail = _head = new Node(item);
            }
            else
            {
                _head= _head.Prev  = new Node(item,  null, _head);
               
            }
        }
        public void ListPushTail(T newItem)
        {
            if (_tail == null)
            {
                _tail = _head = new Node(newItem);
            }
            else
            {
                _tail = _tail.Next = new Node(newItem, _tail, null);
            }
        }
        public T ListPopTail()
        {
            if (_head == null)
            {
                throw new ApplicationException("list is empty");
            }
            if(_head==_tail)
            {
                _head = _tail = null;
            }

            //T item = _tail.Prev.Value;
            T item = _tail.Value;
            _tail = _tail.Prev;
            _tail.Next = null;
            return item;

        }
        public T ListPopHead()
        {
            if (_head == null)
            {
                throw new ApplicationException("list is empty");

            }
            if (_head == _tail)
            {
                _head = _tail = null;
            }

            T temp = this._head.Value;
            this._head = this._head.Next;
            this._head.Prev = null;
            return temp;

        }

        public void ListClear()
        {
            this._head = null;
            this._tail = null;
        }
        public int ListCountItems()
        {
            int count = 0;
            Node item = _head;

            while (item != null)
            {
                ++count;
                item = item.Next;
            }
            return count;
        }
        public bool ListIsEmpty()
        {
            return (_head == null);
        }
        public void ListPushAt(int index, T value)
        {
            if (index < 0 )
            {
                throw new ApplicationException("Out Of Range");

            }
            if (index == 0)
            {
                ListPushHead(value);

            }
            
            
            {
                Node item = _head;
                for (int i = 1; i < index; ++i)
                {
                    if (item.Next == null)
                    {
                        throw new ApplicationException("Out Of Range");

                    }
                    item = item.Next;
                }
                if (item == _tail)
                {
                    ListPushTail(value);
                    return;
                }
               
                item.Next = item.Next.Prev = new Node(value,  item, item.Next);
            }
        }
        public T ListPopAt(int index)
        {
            if (index < 0)
            {
                throw new ApplicationException("Out Of Range");
            }

            if (index == 0)
            {
                return ListPopHead();
            }
            Node item = _head;
            for (int i = 1; i < index; i++)
            {
                if (item.Next == null)
                    throw new ApplicationException("Out Of Range");
                item = item.Next;
            }
            if (item.Next == null )
                throw new ApplicationException("Out Of Range");
            T temp = item.Next.Value;
            item.Next = item.Next.Next;
            if (item.Next != null)
                item.Next.Prev = item;

            return temp;
        }
        public int ListFind(T value)
        {
            Node item = _head;
            for (int i = 0; item.Value != null; i++)
            {
                if (item.Value.Equals(value))
                    return i;
                item = item.Next;
            }
            throw new AppDomainUnloadedException();
        }
        public Node ListGetNode(int index)
        {

            if (index < 0 || _head == null)
            {
                throw new AppDomainUnloadedException();
            }

            int i = 0;
            Node item = _head;

            while (i < index)
            {
                if (item.Next == null)
                    throw new AppDomainUnloadedException();
                item = item.Next;
                ++i;
            }
            return item;


        }

        public void ListAppend(DoubleLinkList<T> newList)
        {
            _tail.Next = newList._head;
            newList._head.Prev = _tail;
            _tail = newList._tail;

        }

        public void Print()
        {
            if (_head == null)
            {
                throw new ApplicationException("list is empty");
            }


            Node item = _head;
            while (item != null)
            {
                Console.WriteLine(item.Value);
                item = item.Next;
            }
        }


    }
}
