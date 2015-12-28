using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    public class LinkedList<T> : IEnumerator , IEnumerable
    {
        private Node headNode;
        private int position = -1;
        private int Size = 0;

        public class Node
        {
            private T data;
            private Node NextNode;

            public T Value { get { return data; } set { data = value; } }
            public Node Next { get {return NextNode; } set {NextNode =  value; } }
        }

        public int Count { get { return Size; } }

        public object Current   // IEnumerator
        {
            get
            {
                return this[position];
            }
        }


        public void Add(T data)
        {
            if (headNode == null)
            {
                headNode = new Node();
                headNode.Value = data;
            }
            else
            {
                Node currentNode = headNode;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                Node node = new Node();
                node.Value = data;
                currentNode.Next = node;
            }
            Size++;
        }


        public void InsertAfter(T key, T data)
        {
            Node currentNode = headNode;
            while(currentNode != null && !currentNode.Value.Equals(key))
            {
                currentNode = currentNode.Next;
            }
            if (currentNode != null)
            {
                Node node = new Node();
                node.Value = data;

                Node helperNode = currentNode.Next;
                currentNode.Next = node;
                node.Next = helperNode;
            } else
            {

                throw new ArgumentException("Key can't be found!");
            }
            Size++;
        }

        public void InsertBefore(T key, T data)
        {
            Node currentNode = headNode;
            while (currentNode != null && !currentNode.Next.Value.Equals(key))
            {
                currentNode = currentNode.Next;
            }
            if (currentNode != null)
            {
                Node node = new Node();
                node.Value = data;

                Node helperNode = currentNode.Next;
                currentNode.Next = node;
                node.Next = helperNode;
            }
            else
            {
                throw new ArgumentException("Key can't be found!");
            }
            Size++;
        }

        public void InsertAt(int index, T data)
        {
            Node currentNode = headNode;
            int currentIndex = 0;

            if (index == 0)
            {
                if (headNode != null)
                {
                    Node node = new Node();
                    node.Value = data;

                    Node helperNode = headNode;
                    headNode = node;
                    headNode.Next = helperNode;
                }
                else
                {
                    Node node = new Node();
                    node.Value = data;
                    headNode = node;
                }
            }
            else
            {
                while (currentIndex != index - 1)
                {
                    currentNode = currentNode.Next;
                    currentIndex++;

                    if (currentNode.Next == null && currentIndex != index - 1)
                    {
                        throw new ArgumentException(" Invalid index!");
                    }
                }

                Node node = new Node();
                node.Value = data;

                if (currentNode.Next == null)
                {
                    currentNode.Next = node;
                }
                else
                {
                    Node helperNode = currentNode.Next;
                    currentNode.Next = node;
                    node.Next = helperNode;
                }

            }

            Size++;
        }


        public void Remove(T data)
        {
            if (headNode.Value.Equals(data))
            {
                headNode = headNode.Next;
            }
            else
            {
                Node currentNode = headNode;
                while (currentNode != null && !currentNode.Next.Value.Equals(data))
                    currentNode = currentNode.Next;

                if (currentNode != null)
                {
                    currentNode.Next = currentNode.Next.Next;
                }
                else
                { 
                    throw new ArgumentException("Value doesn't exist.");
                }
            }
            if (headNode == null)
            {
                throw new ArgumentException("Can't remove from an empty List");
            }
            Size--;
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                headNode = headNode.Next;
            }
            else
            {
                Node currentNode = headNode;
                int curIndex = 0;
                while (currentNode.Next != null && curIndex != index - 1)
                {
                    currentNode = currentNode.Next;
                    curIndex++;
                }

                if (currentNode.Next != null)
                {
                    currentNode.Next = currentNode.Next.Next;
                }
                else
                {
                    throw new ArgumentException("ERROR: Invalid index!");
                }
                if (headNode == null)
                {
                    throw new ArgumentException("Can't remove from an empty List");
                }
            }

            Size--;
        }


        public void Clear()
        {
            headNode = null;
            Size = 0;
        }


        public T this[int index]
        {
            get
            {
                Node currentNode = headNode;
                int currentIndex = 0;

                if (index < Size && index >= 0)
                {
                    while (currentIndex != index)
                    {
                        currentNode = currentNode.Next;
                        currentIndex++;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid index!");
                }
                return currentNode.Value;
            }
            set
            {
                Node currentNode = headNode;
                int currentIndex = 0;

                if (index < Size && index >= 0)
                {
                    while (currentIndex != index)
                    {
                        currentNode = currentNode.Next;
                        currentIndex++;
                    }
                }
                else
                    throw new ArgumentException("Invalid index!");

                currentNode.Value = value;
            }
        }


        public bool MoveNext()
        {
            position++;
            return (position < Size);
        }

        public void Reset()
        {
            position = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
