using NUnit.Framework;
using System;

namespace LinkedListClass.Tests
{
    public class LinkedListTests

    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 7)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 10)]
        [TestCase(new int[] { 0, 0, 0 }, 3)]
        public void GetLengthTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            int actual = list.GetLength();

            //assert
            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 })]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 })]
        [TestCase(new int[] { 0, 0, 0 })]
        public void ToArrayTest(int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);
            int[] expected = array;
            //act          
            int[] actual = list.ToArray();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 33, "33 1 -2 3 2 -98 -56 -33 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 33, "33 0 3 67 23 -45 -67 -23 -23 56 3 ")]
        [TestCase(new int[] { 0, 0, 0 }, 33, "33 0 0 0 ")]
        public void AddFirstTest(int[] array, int val, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            list.AddFirst(val);
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, new int[] { 33, 44, 55, 66 }, "33 44 55 66 1 -2 3 2 -98 -56 -33 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, new int[] { 33, 44, 55, 66 }, "33 44 55 66 0 3 67 23 -45 -67 -23 -23 56 3 ")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 33, 44, 55, 66 }, "33 44 55 66 0 0 0 ")]
        public void AddFirstTest(int[] array, int[] willBeList, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);
            LinkedList enteringList = new LinkedList(willBeList);
            //act          
            list.AddFirst(enteringList);
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 33, "1 -2 3 2 -98 -56 -33 33 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 33, "0 3 67 23 -45 -67 -23 -23 56 3 33 ")]
        [TestCase(new int[] { 0, 0, 0 }, 33, "0 0 0 33 ")]
        public void AddLastTest(int[] array, int val, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            list.AddLast(val);
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, new int[] { 33, 44, 55, 66 }, "1 -2 3 2 -98 -56 -33 33 44 55 66 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, new int[] { 33, 44, 55, 66 }, "0 3 67 23 -45 -67 -23 -23 56 3 33 44 55 66 ")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 33, 44, 55, 66 }, "0 0 0 33 44 55 66 ")]
        public void AddLastTest(int[] array, int[] willBeList, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);
            LinkedList expectedList = new LinkedList(willBeList);
            //act          
            list.AddLast(expectedList);
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 4, 33, "1 -2 3 2 33 -98 -56 -33 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 0, 33, "33 0 3 67 23 -45 -67 -23 -23 56 3 ")]
        [TestCase(new int[] { 0, 0, 0 }, 3, 33, "0 0 0 33 ")]
        public void AddAtTest(int[] array, int position, int val, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            list.AddAt(position, val);
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 3, new int[] { 33, 44, 55, 66 }, "1 -2 3 33 44 55 66 2 -98 -56 -33 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 10, new int[] { 33, 44, 55, 66 }, "0 3 67 23 -45 -67 -23 -23 56 3 33 44 55 66 ")]
        [TestCase(new int[] { 0, 0, 0 }, 0, new int[] { 33, 44, 55, 66 }, "33 44 55 66 0 0 0 ")]
        public void AddAtTest(int[] array, int position, int[] willBeList, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);
            LinkedList expectedList = new LinkedList(willBeList);
            //act          
            list.AddAt(position, expectedList);
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, -4, 33, "Wrong position: index must be positive!")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 44, 33, "Wrong position: we don't have such amount of elements!")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 11, 33, "Wrong position: we don't have such amount of elements!")]
        public void AddAtNegativeTest(int[] array, int position, int val, string expectedMessage)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert

            Exception ex = Assert.Throws(typeof(ArgumentException), () => list.AddAt(position, val));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 3, 33, "1 -2 3 33 -98 -56 -33 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 0, 33, "33 3 67 23 -45 -67 -23 -23 56 3 ")]
        [TestCase(new int[] { 0, 0, 0 }, 2, 33, "0 0 33 ")]
        public void SetTest(int[] array, int position, int val, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            list.Set(position, val);
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 7, 33, "Wrong position: we don't have such amount of elements!")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, -1, 33, "Wrong position: index must be positive!")]
        public void SetNegativeTest(int[] array, int position, int val, string expectedMessage)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert

            Exception ex = Assert.Throws(typeof(ArgumentException), () => list.Set(position, val));
            Assert.AreEqual(expectedMessage, ex.Message);
        }


        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, "-2 3 2 -98 -56 -33 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, "3 67 23 -45 -67 -23 -23 56 3 ")]
        [TestCase(new int[] { 0, 0, 0 }, "0 0 ")]
        public void RemoveFirstTest(int[] array, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            list.RemoveFirst();
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, "1 -2 3 2 -98 -56 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, "0 3 67 23 -45 -67 -23 -23 56 ")]
        [TestCase(new int[] { 0, 0, 0 }, "0 0 ")]
        public void RemoveLastTest(int[] array, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            list.RemoveLast();
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 4, "1 -2 3 2 -56 -33 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 0, "3 67 23 -45 -67 -23 -23 56 3 ")]
        [TestCase(new int[] { 0, 0, 0 }, 2, "0 0 ")]
        public void RemoveAtTest(int[] array, int position, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            list.RemoveAt(position);
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, -4, "Wrong position: index must be positive!")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 10, "Wrong position: we don't have such amount of elements!")]
        [TestCase(new int[] { 0, 0, 0 }, 12, "Wrong position: we don't have such amount of elements!")]
        public void RemoveAtNegativeTest(int[] array, int position, string expectedMessage)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert

            Exception ex = Assert.Throws(typeof(ArgumentException), () => list.RemoveAt(position));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 2, "3 2 -98 -56 -33 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 10, "")]
        [TestCase(new int[] { 0, 0, 0 }, 1, "0 0 ")]
        public void RemoveFirstMultipleTest(int[] array, int amount, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            list.RemoveFirstMultiple(amount);
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, -7, "Wrong amount: it must be positive!")]
        public void RemoveFirstMultipleNegativeTest(int[] array, int amount, string expectedMessage)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert

            Exception ex = Assert.Throws(typeof(ArgumentException), () => list.RemoveFirstMultiple(amount));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 2, "1 -2 3 2 -98 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 10, "")]
        [TestCase(new int[] { 0, 0, 0 }, 1, "0 0 ")]
        public void RemoveLastMultipleTest(int[] array, int amount, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            list.RemoveLastMultiple(amount);
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, -7, "Wrong amount: it must be positive!")]
        public void RemoveLastMultipleNegativeTest(int[] array, int amount, string expectedMessage)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert

            Exception ex = Assert.Throws(typeof(ArgumentException), () => list.RemoveLastMultiple(amount));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 1, 2, "1 2 -98 -56 -33 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 6, 7, "0 3 67 23 -45 -67 ")]
        [TestCase(new int[] { 0, 0, 0 }, 0, 1, "0 0 ")]
        public void RemoveAtMultipleTest(int[] array, int index, int amount, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            list.RemoveAtMultiple(index, amount);
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, -5, 4, "Wrong position: index must be positive!")]
        [TestCase(new int[] { 0, 0, 0 }, 0, -1, "Wrong amount: amount must be positive!")]
        public void RemoveAtMultipleNegativeTest(int[] array, int index, int amount, string expectedMessage)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert

            Exception ex = Assert.Throws(typeof(ArgumentException), () => list.RemoveAtMultiple(index, amount));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, -33, 6)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 67, 2)]
        [TestCase(new int[] { 0, 0, 0 }, 3, -1)]
        public void RemoveFirstTest(int[] array, int val, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            int actual = list.RemoveFirst(val);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -33, 3, -33, -98, -56, -33 }, -33, 3)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 67, 1)]
        [TestCase(new int[] { 0, 0, 0 }, 3, 0)]
        public void RemoveAllTest(int[] array, int val, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            int actual = list.RemoveAll(val);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -33, 3, -33, -98, -56, -33 }, -33, true)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 100, false)]
        [TestCase(new int[] { 0, 0, 0 }, 0, true)]
        public void ContainsTest(int[] array, int val, bool expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            bool actual = list.Contains(val);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -33, 3, -33, -98, -56, -33 }, -33, 1)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 100, -1)]
        [TestCase(new int[] { 0, 0, 0 }, 0, 0)]
        public void IndexOfTest(int[] array, int val, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            int actual = list.IndexOf(val);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -33, 3, -33, -98, -56, -33 }, 1)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 0)]
        [TestCase(new int[] { 0, 0, 0 }, 0)]
        public void GetFirstTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            int actual = list.GetFirst();

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, -33, 3, -33, -98, -56, -33 }, -33)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 3)]
        [TestCase(new int[] { 0, 0, 0 }, 0)]
        public void GetLastTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            int actual = list.GetLast();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -33, 3, -33, -98, -56, -33 }, 2, 3)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 5, -67)]
        [TestCase(new int[] { 0, 0, 0 }, 2, 0)]
        public void GetTest(int[] array, int index, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            int actual = list.Get(index);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -33, 3, -33, -98, -56, -33 }, 7, "Wrong position: we don't have such amount of elements!")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, -5, "Wrong position: index must be positive!")]
        public void GetNegativeTest(int[] array, int index, string expectedMessage)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert

            Exception ex = Assert.Throws(typeof(ArgumentException), () => list.Get(index));
            Assert.AreEqual(expectedMessage, ex.Message);
        }



        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, -98)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, -67)]
        [TestCase(new int[] { 0, 0, 0 }, 0)]
        public void MinTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            int actual = list.Min();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 3)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 67)]
        [TestCase(new int[] { 0, 0, 0 }, 0)]
        public void MaxTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            int actual = list.Max();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 4)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 5)]
        [TestCase(new int[] { 0, 0, 0 }, 0)]
        public void IndexOfMinTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            int actual = list.IndexOfMin();

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, 2)]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, 2)]
        [TestCase(new int[] { 0, 0, 0 }, 0)]
        public void IndexOfMaxTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            int actual = list.IndexOfMax();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, "-33 -56 -98 2 3 -2 1 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, "3 56 -23 -23 -67 -45 23 67 3 0 ")]
        [TestCase(new int[] { 0, 0, 0 }, "0 0 0 ")]
        public void ReverseTest(int[] array, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act          
            list.Reverse();
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, "-98 -56 -33 -2 1 2 3 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, "-67 -45 -23 -23 0 3 3 23 56 67 ")]
        [TestCase(new int[] { 0, 0, 0 }, "0 0 0 ")]
        public void SortTest(int[] array, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.Sort();
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, "3 2 1 -2 -33 -56 -98 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, "67 56 23 3 3 0 -23 -23 -45 -67 ")]
        [TestCase(new int[] { 0, 0, 0 }, "0 0 0 ")]
        public void SortDescTest(int[] array, string expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.SortDesc();
            string actual = list.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}