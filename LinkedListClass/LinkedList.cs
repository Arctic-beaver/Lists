using System;

namespace LinkedListClass
{
    public class LinkedList
    {

        private Node _head;
        private Node _tail;

        public LinkedList()
        {
            _head = null;
            _tail = null;
        }

        public LinkedList(int val)
        {
            InitHeadAndTail();
            Node new_node = new Node(val);
            _head = new_node;
            _tail = new_node;
        }

        public LinkedList(int[] array)
        {
            InitHeadAndTail();
            if (array.Length == 0) return;

            Node shovel = new Node(array[0]);
            _head = shovel;

            for (int i = 1; i < array.Length; i++)
            {
                shovel.Next = new Node(array[i]);
                shovel = shovel.Next;
            }
            _tail = shovel;
        }

        public void print()
        {
            Console.WriteLine();
            string str = ToString();
            Console.WriteLine(str);
        }

        public override string ToString()
        {
            Node shovel = _head;
            string str = "";
            while (shovel != null)
            {
                str += $"{shovel.Data} ";
                shovel = shovel.Next;
            }
            return str;
        }

        private void InitHeadAndTail()
        {
            _head = new Node();
            _tail = new Node();
        }

        public int GetLength()
        {
            int length = 0;

            Node shovel = _head;
            while (shovel != null)
            {
                length += 1;
                shovel = shovel.Next;
            }

            return length;
        }

        public int[] ToArray()
        {
            int length = GetLength();
            if (length == 0) return new int[] { };

            int[] array = new int[length];
            Node shovel = _head;
            for (int i = 0; i < length; i++)
            {
                array[i] = shovel.Data;
                shovel = shovel.Next;
            }

            return array;
        }

        public void AddFirst(int val)
        {
            Node new_node = new Node(val);
            if (_head == null)
            {
                _head = new_node;
                _tail = new_node;
            }
            else
            {
                new_node.Next = _head;
                _head = new_node;
            }
        }

        public void AddFirst(LinkedList list)
        {
            list._tail.Next = _head;
            _head = list._head;
            if (_tail == null) _tail = list._tail;
        }

        public void AddLast(int val)
        {
            Node new_node = new Node(val);
            if (_head == null)
            {
                _head = new_node;
                _tail = new_node;
            }
            else
            {
                _tail.Next = new_node;
                _tail = new_node;
            }
        }

        public void AddLast(LinkedList list)
        {
            if (_head == null)
            {
                _head = list._head;
                _tail = list._tail;
            }
            else
            {
                _tail.Next = list._head;
                _tail = list._tail;
            }
        }


        public void AddAt(int idx, int val)
        {
            if (idx == 0)
            {
                AddFirst(val);
                return;
            }

            Node previous = GetNode(idx - 1);
            if (previous == _tail)
            {
                AddLast(val);
            }
            else
            {
                Node new_node = new Node(val);
                new_node.Next = previous.Next;
                previous.Next = new_node;
            }
        }

        public void AddAt(int idx, LinkedList list)
        {
            if (idx == 0)
            {
                AddFirst(list);
                return;
            }

            Node previous = GetNode(idx - 1);
            if (previous == _tail)
            {
                AddLast(list);
            }
            else
            {
                list._tail.Next = previous.Next;
                previous.Next = list._head;
            }
        }

        public void Set(int idx, int val)
        {
            Node changing = GetNode(idx);
            changing.Data = val;
        }

        public void RemoveFirst()
        {
            if (_head == null) return;
            if (_head.Equals(_tail))
            {
                _head = null;
                _tail = null;
                return;
            }
            _head = _head.Next;
        }


        public void RemoveLast()
        {
            if (_head == null) return;
            if (_head.Equals(_tail))
            {
                _head = null;
                _tail = null;
                return;
            }
            //here in doubly make it simple
            Node shovel = _head;
            while (shovel.Next.Next != null)
            {
                shovel = shovel.Next;
            }
            _tail = shovel;
            shovel.Next = null;
        }

        public void RemoveAt(int idx)
        {
            if (idx == 0)
            {
                RemoveFirst();
                return;
            }

            Node removablePrev = GetNode(idx - 1);
            if (removablePrev == _tail) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (removablePrev.Next == _tail)
            {
                RemoveLast();
                return;
            }

            removablePrev.Next = removablePrev.Next.Next;
        }

        public void RemoveFirstMultiple(int n)
        {
            if (n < 0) throw new ArgumentException("Wrong amount: it must be positive!");
            int counterOfdeletedElementsAmount = 0;
            while (_head != null && counterOfdeletedElementsAmount < n)
            {
                _head = _head.Next;
                counterOfdeletedElementsAmount += 1;
            }
            if (_head == null)
            {
                _tail = null;
                //deleted all elements
            }
        }

        public void RemoveLastMultiple(int n)
        {
            if (n < 0) throw new ArgumentException("Wrong amount: it must be positive!");

            int length = GetLength();
            int index = length - n - 1;
            if (index < 0) _head = null;
            else
            {
                Node lasEl = GetNode(index, length);
                lasEl.Next = null;
                _tail = lasEl;
            }
        }

        public void RemoveAtMultiple(int idx, int n)
        {
            if (n < 0) throw new ArgumentException("Wrong amount: amount must be positive!");
            if (idx == 0)
            {
                RemoveFirstMultiple(n);
                return;
            }

            int counterOfdeletedElementsAmount = 0;
            Node shovel = GetNode(idx - 1);

            while (shovel.Next != null && counterOfdeletedElementsAmount < n)
            {
                shovel.Next = shovel.Next.Next;
                counterOfdeletedElementsAmount += 1;
            }
            if (shovel.Next == null)
            {
                _tail = shovel;
            }
        }

        public int RemoveFirst(int val)
        {
            Node shovel = _head;
            int idx = 0;

            while (shovel != null)
            {
                if (shovel.Data == val)
                {
                    RemoveAt(idx);
                    return idx;
                }
                idx += 1;
                shovel = shovel.Next;
            }
            return -1;
        }


        public int RemoveAll(int val)
        {
            Node shovel = _head;
            int idx = 0;
            int counter = 0;
            Node removablePrev = null;
            while (shovel != null)
            {
                if (shovel.Data == val)
                {
                    if (removablePrev == null)
                    {
                        RemoveFirst();
                    }
                    else if (removablePrev == _tail) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
                    else if (removablePrev.Next == _tail)
                    {
                        RemoveLast();
                    }
                    else removablePrev.Next = removablePrev.Next.Next;

                    counter += 1;
                }
                idx += 1;
                removablePrev = shovel;
                shovel = shovel.Next;
            }
            return counter;
        }

        public bool Contains(int val)
        {
            Node shovel = _head;
            int idx = 0;
            while (shovel != null)
            {
                if (shovel.Data == val)
                {
                    return true;
                }
                idx += 1;
                shovel = shovel.Next;
            }
            return false;
        }

        public int IndexOf(int val)
        {
            Node shovel = _head;
            int idx = 0;

            while (shovel != null)
            {
                if (shovel.Data == val)
                {
                    return idx;
                }
                idx += 1;
                shovel = shovel.Next;
            }
            return -1;
        }

        public int GetFirst()
        {
            if (_head == null) throw new IndexOutOfRangeException("Your list is empty!");
            return _head.Data;
        }

        public int GetLast()
        {
            if (_head == null) throw new IndexOutOfRangeException("Your list is empty!");
            return _tail.Data;
        }


        private Node GetNode(int idx, int length)
        {
            if (idx >= length) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");

            Node shovel = _head;
            int idxReal = 0;

            while (idxReal < idx)
            {
                shovel = shovel.Next;
                idxReal += 1;
            }

            return shovel;
        }

        private Node GetNode(int idx)
        {
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            int length = GetLength();
            if (idx >= length) throw new ArgumentException("Wrong position: we don't have such amount of elements!");

            Node shovel = _head;
            int idxReal = 0;

            while (idxReal < idx)
            {
                shovel = shovel.Next;
                idxReal += 1;
            }

            return shovel;
        }

        public int Get(int idx)
        {
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            int length = GetLength();
            if (idx >= length) throw new ArgumentException("Wrong position: we don't have such amount of elements!");

            Node shovel = _head;
            int idxReal = 0;

            while (idxReal < idx)
            {
                shovel = shovel.Next;
                idxReal += 1;
            }

            return shovel.Data;
        }

        public void Reverse()
        {
            RecursiveReverse(ref _head);
        }

        private void RecursiveReverse(ref Node node)
        {
            if (node == null || node.Next == null) return;

            Node left;
            Node next;

            left = node;
            next = left.Next;

            RecursiveReverse(ref next);

            left.Next.Next = left;
            left.Next = null;
            node = next;
        }

        public int Max()
        {
            Node shovel = _head;
            int max = -900000000;

            while (shovel != null)
            {
                if (shovel.Data > max)
                {
                    max = shovel.Data;
                }
                shovel = shovel.Next;
            }
            return max;
        }

        public int Min()
        {
            Node shovel = _head;
            int min = 900000000;

            while (shovel != null)
            {
                if (shovel.Data < min)
                {
                    min = shovel.Data;
                }
                shovel = shovel.Next;
            }
            return min;
        }

        public int IndexOfMax()
        {
            Node shovel = _head;
            int max = -900000000;
            int idx = 0;
            int idxOfMax = 0;

            while (shovel != null)
            {
                if (shovel.Data > max)
                {
                    max = shovel.Data;
                    idxOfMax = idx;
                }
                idx += 1;
                shovel = shovel.Next;
            }
            return idxOfMax;
        }

        public int IndexOfMin()
        {
            Node shovel = _head;
            int min = 900000000;
            int idx = 0;
            int idxOfMin = 0;

            while (shovel != null)
            {
                if (shovel.Data < min)
                {
                    min = shovel.Data;
                    idxOfMin = idx;
                }
                idx += 1;
                shovel = shovel.Next;
            }
            return idxOfMin;
        }

        private void InsertionSort(bool desc)
        {
            LinkedList sorted = new LinkedList();

            Node shovel = _head;

            while (shovel != null)
            {
                InsertNewNodeInAList(shovel, ref sorted._head, ref sorted._tail, desc);
                shovel = shovel.Next;
            }

            _head = sorted._head;
        }

        private Node Clone(Node node)
        {
            Node clone = new Node(node.Data);
            return clone;
        }

        private void InsertNewNodeInAList(Node node, ref Node head, ref Node tail, bool desc)
        {
            Node newNode = Clone(node);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }

            Node shovel = head;
            Node prevToPutNewNode = null;

            if (desc)
            {
                while (shovel != null && shovel.Data > newNode.Data)
                {
                    prevToPutNewNode = shovel;
                    shovel = shovel.Next;
                }
            }
            else
            {
                while (shovel != null && shovel.Data < newNode.Data)
                {
                    prevToPutNewNode = shovel;
                    shovel = shovel.Next;
                }
            }

            Node tmp;

            if (prevToPutNewNode == null)
            {
                tmp = head;
                head = newNode;
                newNode.Next = tmp;
                return;
            }

            if (prevToPutNewNode == tail)
            {
                prevToPutNewNode.Next = newNode;
                tail = newNode;
                return;
            }

            tmp = prevToPutNewNode.Next;
            prevToPutNewNode.Next = newNode;
            newNode.Next = tmp;
        }


        public void Sort()
        {
            InsertionSort(false);
        }


        public void SortDesc()
        {
            InsertionSort(true);
        }
    }
}
