using System;
//using System.Collections.Generic;
//using System.Text;

namespace AbstractCollections
{
    class SingleList<T>
    {
        public class Node
        {
            private T value;
            private Node next;
            public Node Next { get => next; set => next = value; }
            public T Value { get => value; set => this.value = value; }

            public Node(T item)
            {
                this.value = item;
                this.next = null;
            }
            public Node(T item, Node next)
            {
                this.value = item;
                this.next = next;
            }


        }

        private Node head;
        private Node tail;

        public SingleList()
        {
            head = tail = null;

        }

        public void ListPushHead(T item)
        {
            if (head == null)
                tail = head = new Node(item);
            else
                head = new Node(item, head);


        }
        public void ListPushTail(T newItem)
        {
            if (tail == null)
                tail = head = new Node(newItem);
            else
                tail = tail.Next = new Node(newItem);


        }
        public T ListPopTail()
        {
            if (head == null)
            {
                throw new ApplicationException("list is empty");
            }
            Node temp = head;
            while (temp.Next != tail)
            {
                temp = temp.Next;
            }

            T item = temp.Next.Value;
            tail = temp;
            temp.Next = null;


            return item;
        }
        public T ListPopHead()
        {
            if (head == null)
            {
                throw new ApplicationException("list is empty");
            }

            T temp = this.head.Value;
            this.head = this.head.Next;
            return temp;

        }

        public void ListClear()
        {
            this.head = null;
            this.tail = null;
        }
        public int ListCountItems()
        {
            int count = 0;
            Node item = head;

            while (item != null)
            {
                ++count;
                item = item.Next;
            }
            return count;
        }
        public bool ListIsEmpty()
        {
            return (head == null);
        }
        public void ListPushAt(int index, T value)
        {
            if (index < 0)
            {
                throw new ApplicationException("Out Of Range");

            }
            if (index == 0)
            {
                ListPushHead(value);

            }
            else
            {
                Node item = head;
                for (int i = 1; i < index; ++i)
                {
                    if (item.Next == null)
                        throw new ApplicationException("Out Of Range");
                    item = item.Next;
                }
                item.Next = new Node(value, item.Next);
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
            Node item = head;
            for (int i = 1; i < index; i++)
            {
                if (item.Next == null)
                    throw new ApplicationException("Out Of Range");
                item = item.Next;
            }
            T temp = item.Next.Value;
            item.Next = item.Next.Next;
            return temp;
        }
        public int ListFind(T value)
        {
            Node item = head;
            for (int i = 0; item.Next != null; i++)
            {
                if (item.Value.Equals(value))
                    return i;
            }
            throw new AppDomainUnloadedException();
        }
        public Node ListGetNode(int index)
        {

            if (index < 0 || head == null)
                throw new AppDomainUnloadedException();

            int i = 0;
            Node item = head;
            
            while (i < index)
            {
                if (item.Next == null)
                    throw new AppDomainUnloadedException();
                item = item.Next;
                ++i;
            }
            return item;


        }

        public void ListAppend(SingleList<T> newList)
        {
            tail.Next = newList.head;
            tail = newList.tail;

        }

        public void Print()
        {
            if (head == null)
            {
                throw new ApplicationException("list is empty");
            }


            Node item = head;
            while (item != null)
            {
                Console.WriteLine(item.Value);
                item = item.Next;
            }
        }
        public void ListRevers()
        {
            //  1 2 3 4 5  

            Node prev = null;
            Node current = head;
            Node next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = tail;
            tail = current;




        }

        public Node RecursiaRevers(Node node)
        {
            if(node==null || node.Next == null)
            {
                return node;
            }
            Node temp = RecursiaRevers(node.Next);
            node.Next.Next = node;
            node.Next = null;
            head = temp;
            tail= node;
            return temp;

        }


    }
}
