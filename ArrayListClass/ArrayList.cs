using System;

namespace ArrayListClass
{
    public class ArrayList
    {
        private int[] _array;

        private int FilledLength;

        public ArrayList()
        {
            _array = new int[15];
            var randomizer = new Random();
            for (int i = 0; i < 10; i++)
            {
                _array[i] = randomizer.Next(1, 100);
            }

            FilledLength = 10;
        }

        public ArrayList(int element)
        {
            _array = new int[10];
            _array[0] = element;
            FilledLength = 1;
        }

        public ArrayList(int[] givenArray)
        {
            _array = givenArray;
            FilledLength = _array.Length;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < FilledLength; i++)
            {
                str += $"{_array[i]} ";
            }
            return str;
        }

        public int GetLength()
        {
            return FilledLength;
        }

        public int[] ToArray()
        {
            int[] outputArray = new int[FilledLength];
            for (int i = 0; i < FilledLength; i++)
            {
                outputArray[i] = _array[i];
            }
            return outputArray;
        }

        private void ShiftArrayElementsForward(int numberOfPositionsToShift, int positionStartShift)
        {
            while (FilledLength + numberOfPositionsToShift > _array.Length) Resize();
            for (int i = FilledLength + numberOfPositionsToShift - 1; i >= numberOfPositionsToShift + positionStartShift; i--)
            {
                _array[i] = _array[i - numberOfPositionsToShift];
            }
            FilledLength += numberOfPositionsToShift;
        }

        private void Resize()
        {
            int[] biggerArray = new int[(_array.Length * 3) / 2];

            for (int i = 0; i < _array.Length; i++)
            {
                biggerArray[i] = _array[i];
            }
            _array = biggerArray;
        }

        public void AddFirst(int val)
        {
            ShiftArrayElementsForward(1, 0);
            _array[0] = val;
        }

        public void AddFirst(ArrayList list)
        {
            ShiftArrayElementsForward(list.GetLength(), 0);
            for (int i = 0; i < list.GetLength(); i++)
            {
                _array[i] = list.Get(i);
            }
        }

        public void AddLast(int val)
        {
            if (FilledLength == _array.Length) Resize();
            _array[FilledLength] = val;
            FilledLength += 1;
        }

        public void AddLast(ArrayList list)
        {
            while (FilledLength + list.GetLength() > _array.Length) Resize();
            for (int i = FilledLength, j = 0; i < FilledLength + list.GetLength(); j++, i++)
            {
                _array[i] = list.Get(j);
            }
            FilledLength += list.GetLength();
        }

        public void AddAt(int idx, int val)
        {
            if (idx > FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (idx < FilledLength)
            {
                ShiftArrayElementsForward(1, idx);
            }
            else if (FilledLength == _array.Length)
            {
                Resize();
                FilledLength += 1;
            }
            _array[idx] = val;
        }

        public void AddAt(int idx, ArrayList list)
        {
            if (idx > FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (idx < FilledLength)
            {
                ShiftArrayElementsForward(list.GetLength(), idx);
            }
            else if (FilledLength == _array.Length)
            {
                while (FilledLength + list.GetLength() > _array.Length) Resize();
                FilledLength += list.GetLength();
            }
            for (int i = idx, j = 0; i < list.GetLength() + idx; j++, i++)
            {
                _array[i] = list.Get(j);
            }
        }

        public void Set(int idx, int val)
        {
            if (idx >= FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            _array[idx] = val;
        }

        private void ShiftArrayElementsBackward(int numberOfPositionsToShift, int positionStartShift)
        {
            while (FilledLength + numberOfPositionsToShift > _array.Length) Resize();
            for (int i = positionStartShift; i < FilledLength - numberOfPositionsToShift; i++)
            {
                _array[i] = _array[i + numberOfPositionsToShift];
            }
            FilledLength -= numberOfPositionsToShift;
            ResizeMinimize();
        }

        private void ResizeMinimize()
        {
            bool isClear = false;
            if (FilledLength == 0)
            {
                FilledLength = 10;
                isClear = true;
            }
            while (FilledLength <= (_array.Length * 2) / 3)
            {
                int[] smallerArray = new int[(_array.Length * 2) / 3];

                for (int i = 0; i < FilledLength; i++)
                {
                    smallerArray[i] = _array[i];
                }
                _array = smallerArray;
            }
            if (isClear) FilledLength = 0;
        }

        public void RemoveFirst()
        {
            ShiftArrayElementsBackward(1, 0);
        }

        public void RemoveLast()
        {
            FilledLength -= 1;
            ResizeMinimize();
        }

        public void RemoveAt(int idx)
        {
            if (idx >= FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (idx == 0) RemoveFirst();
            else if (idx == FilledLength - 1) RemoveLast();
            else
            {
                ShiftArrayElementsBackward(1, idx);
            }
        }

        public void RemoveFirstMultiple(int n)
        {
            if (n > FilledLength) throw new ArgumentException("Wrong amount: we don't have such amount of elements!");
            if (n < 0) throw new ArgumentException("Wrong amount: amount must be positive!");
            if (n == FilledLength)
            {
                FilledLength = 0;
                ResizeMinimize();
            }
            else ShiftArrayElementsBackward(n, 0);
        }

        public void RemoveLastMultiple(int n)
        {
            if (n > FilledLength) throw new ArgumentException("Wrong amount: we don't have such amount of elements!");
            if (n < 0) throw new ArgumentException("Wrong amount: amount must be positive!");
            if (n == FilledLength)
            {
                FilledLength = 0;
                ResizeMinimize();
            }
            else
            {
                FilledLength -= n;
                ResizeMinimize();
            }
        }

        public void RemoveAtMultiple(int idx, int n)
        {
            if (idx + n >= FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (n < 0) throw new ArgumentException("Wrong amount: amount must be positive!");

            if (idx + n == FilledLength - 1) RemoveLastMultiple(n);
            else ShiftArrayElementsBackward(n, idx);
        }

        public int RemoveFirst(int val)
        {
            int index = IndexOf(val);
            if (index != -1)
            {
                RemoveAt(index);
            }
            return index;
        }


        public int RemoveAll(int val) //- удалить все элементы, равные val(вернуть кол-во удалённых элементов)
        {
            int amount = 0;
            while (RemoveFirst(val) != -1)
            {
                amount += 1;
            }
            return amount;
        }

        public bool Contains(int val) //- проверка, есть ли элемент в списке
        {
            if (IndexOf(val) != -1) return true;
            else return false;
        }

        public int IndexOf(int val) //- вернёт индекс первого найденного элемента, равного val(или -1, если элементов с таким значением в списке нет)
        {
            for (int i = 0; i < FilledLength; i++)
            {
                //return position
                if (_array[i] == val) return i;
            }
            //if we haven't got such an element
            return -1;
        }

        public int GetFirst()
        {
            return _array[0];
        }

        public int GetLast()
        {
            return _array[FilledLength - 1];
        }

        public int Get(int idx)
        {
            if (idx >= FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            return _array[idx];
        }

        private void Swap(int indexF, int indexSec)
        {
            int tmp = _array[indexF];
            _array[indexF] = _array[indexSec];
            _array[indexSec] = tmp;
        }

        public void Reverse()
        {
            for (int i = 0; i < FilledLength / 2; i++)
            {
                Swap(i, FilledLength - 1 - i);
            }
        }

        public int Max()
        {
            int maxEl = -1000000000;
            for (int i = 0; i < FilledLength; i++)
            {
                if (_array[i] > maxEl) maxEl = _array[i];
            }
            return maxEl;
        }

        public int Min()
        {
            int minEl = 1000000000;
            for (int i = 0; i < FilledLength; i++)
            {
                if (_array[i] < minEl) minEl = _array[i];
            }
            return minEl;
        }

        public int IndexOfMax()
        {
            return IndexOf(Max());
        }

        public int IndexOfMin()
        {
            return IndexOf(Min());
        }

        public void Sort()
        {
            int sortingLength = _array.Length;
            while (sortingLength > 1)
            {
                int maxEl = -1000000000;
                int indexMaxEl = 0;
                for (int i = 0; i < sortingLength; i++)
                {
                    if (_array[i] > maxEl)
                    {
                        maxEl = _array[i];
                        indexMaxEl = i;
                    }
                }
                sortingLength--;
                Swap(indexMaxEl, sortingLength);
            }
        }

        public void SortDesc()
        {
            bool somethingHappened = true;
            while (somethingHappened)
            {
                somethingHappened = false;
                for (int i = 0; i < _array.Length - 1; i++)
                {
                    if (_array[i] < _array[i + 1])
                    {
                        somethingHappened = true;
                        Swap(i, i + 1);
                    }
                }
            }
        }

        /*void WriteArray()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write($"{_array[i]}\t");
            }
            Console.WriteLine();
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();
        }*/
    }
}