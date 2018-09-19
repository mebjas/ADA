using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 5, 2, 1, 4, 3, 5, 0, 9 };
            int[] sorted = new HeapSort(data, data.Length).Sort();
            HeapSort.PrintArray(sorted, sorted.Length);
            Console.ReadKey();
        }
    }
}