using LinkedListClass;
using System;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            for (int i = 0; i < 10; i++)
            {
                array[i] = i;
            }

            LinkedList list = new LinkedList(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 });

            list.Sort();

            list.print();


        }
    }
}
