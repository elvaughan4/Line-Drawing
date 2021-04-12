using System;
using System.Collections.Generic;
using System.Text;

namespace Line_Drawing
{
    class LinkedList
    {
        private class Node
        {
            private object _data = null;
            private Node _next = null;

            public object Data
            {
                get { return _data; }
                set { _data = value; }
            }

            public Node Next
            {
                get { return _next; }
                set { _next = value; }
            }

            public Node(object newData = null)
            {
                Data = newData;
            }
        }
        private Node _head = null;
        private Node _tail = null;
        private int _count = 0;

        public int Count {
            get { return _count; }
            private set { _count = value; }
        }

        public LinkedList()
        {

        }
        public void Add(object newData)
        {
            Node newNode = new Node(newData);
            Count++;

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
        }

        public int IndexOf(object searchElement)
        {
            for (int i = 0; i < Count; i++)
            {
                object currentNode = Get(i);

                if (currentNode == searchElement)
                {
                    return i;
                }
            }
            return -1;
        }

        public void GreatlyOverworkedYetFullyFunctionalRemove(int targetIndex)
        {
            Node tempNode = _head;
            Node currentNode = _head;
            int counter = 0;

            while (counter < targetIndex)
            {
                tempNode = currentNode;
                currentNode = currentNode.Next;
                counter++;
            }

            if (tempNode == _head)
            {
                RemoveFront();
            }
            else if (tempNode == _tail)
            {
                RemoveRear();
            }
            else
            {
                RemoveMiddle(targetIndex);
            }
        }

        public void Remove(int targetIndex)
        {
            if (targetIndex == 0)
            {
                RemoveFront();
            }
            else if (targetIndex == Count)
            {
                RemoveRear();
            }
            else
            {
                RemoveMiddle(targetIndex);
            }
        }

        private void RemoveFront()
        {
            Node tempNode = _head;

            _head = _head.Next;
            tempNode = null;
            Count--;
        }

        private void RemoveRear()
        {
            Node tempNode = _head;
            Node currentNode = _head;

            while (currentNode.Next != null)
            {
                tempNode = currentNode;
                currentNode = currentNode.Next;
                if (currentNode.Next == null)
                {
                    tempNode.Next = null;
                }
            }
            Count--;
        }

        private void RemoveMiddle(int targetIndex)
        {
            Node tempNode = _head;
            Node currentNode = _head;
            int counter = 0;

            while (counter < targetIndex)
            {
                tempNode = currentNode;
                currentNode = currentNode.Next;
                counter++;
            }

            tempNode.Next = currentNode.Next;
            currentNode = null;
            Count--;
        }

        public object Get(int targetIndex)
        {
            int currentIndex = 0;
            Node currentNode = _head;

            while (currentNode != null) 
            {
                if (currentIndex == targetIndex)
                {
                    return currentNode.Data;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }

            throw new IndexOutOfRangeException();
        }

        public void Set(int targetIndex, object newData)
        {
            int currentIndex = 0; 
            Node currentNode = _head;

            if (currentNode == null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                while (currentNode.Data != newData)
                {
                    if (currentIndex == targetIndex)
                    {
                        currentNode.Data = newData;
                    }
                    if (currentNode.Data != newData)
                    {
                        currentNode = currentNode.Next;
                        currentIndex++;
                    }
                }
            }
        }

        public object this [int index]
        {
            get 
            {
               return Get(index);
            }
            set { Set(index, value); }
        }

        public override string ToString()
        {
            int currentIndex = 0;
            string returnString = "[";
            Node currentNode = _head;

            if (currentNode == null)
            {
                returnString += "List is empty";
            }
            else
            {
                while (currentIndex < Count)
                {
                    if (currentNode.Next != null)
                    {
                        returnString += currentNode.Data.ToString() + ", ";
                    }
                    else
                    {
                        returnString += currentNode.Data.ToString();
                    }
                    currentNode = currentNode.Next;
                    currentIndex++;
                }
            }
            returnString += "]";
            return returnString;
        }

        public void Clear()
        {
            _tail = null;
            _head = null;
        }

        public void Print()
        {
            int currentIndex = 0;
            string returnString = "[";
            Node currentNode = _head;

            if (currentNode == null)
                throw new IndexOutOfRangeException();
            else
            {
                while (currentIndex < Count)
                {
                    if (currentNode.Next != null)
                        returnString += currentNode.Data.ToString() + ", ";
                    else
                        returnString += currentNode.Data.ToString() + "]";

                    currentNode = currentNode.Next;
                    currentIndex++;
                }
            }
            Console.WriteLine(returnString);
        }

        public object FrontAppend(int targetIndex, object newData)
        {
            int currentIndex = 0;
            Node currentNode = _head;
            Node appendededNode = _head;

            if (currentNode == null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                while (currentNode.Data != newData)
                {
                    if (currentIndex == targetIndex)
                    {
                        appendededNode.Data = newData.ToString() + appendededNode.Data.ToString();
                        return appendededNode.Data;
                    }
                    if (currentNode.Data != newData)
                    {
                        currentNode = currentNode.Next;
                        appendededNode = appendededNode.Next;
                        currentIndex++;
                    }
                }
                currentNode.Data = appendededNode.Data;
            }
            throw new IndexOutOfRangeException();
        }

        public object RearAppend(int targetIndex, object newData)
        {
            int currentIndex = 0;
            Node currentNode = _head;
            Node appndedNode = _head;

            if (currentNode == null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                while (currentNode.Data != newData)
                {
                    if (currentIndex == targetIndex)
                    {
                        appndedNode.Data = currentNode.Data.ToString() + newData.ToString();
                        return appndedNode.Data;
                    }
                    if (currentNode.Data != newData)
                    {
                        currentNode = currentNode.Next;
                        appndedNode = appndedNode.Next;
                        currentIndex++;
                    }
                }
                throw new IndexOutOfRangeException();
            }
        }

        public static LinkedList operator +(LinkedList list1, LinkedList list2)
        {
            LinkedList combinedList = new LinkedList();

            for (int i = 0; i < list1.Count; i++)
            {
                combinedList.Add(list1[i]);
            }

            for (int i = 0; i < list2.Count; i++)
            {
                combinedList.Add(list2[i]);
            }
            return combinedList;
        }
    }
}
