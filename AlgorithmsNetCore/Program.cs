namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 5, 2, 1, 4, 3, 5, 0, 9, 5, 4, 3, 2, 1, 0 };

            Console.WriteLine("Heap Sort");
            int[] sorted1 = new HeapSort(data, data.Length).Sort();
            HeapSort.PrintArray(sorted1, sorted1.Length);

            Console.WriteLine("Quick Sort");
            int[] sorted2 = new QuickSort(data, data.Length).Sort();
            QuickSort.PrintArray(sorted1, sorted1.Length);

            Console.WriteLine("Merge Sort");
            int[] sorted3 = new MergeSort(data, data.Length).Sort();
            MergeSort.PrintArray(sorted1, sorted1.Length);

            Console.WriteLine("Graph - BFS");
            Graph g = new Graph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            g.BFS(2, (i) => Console.Write("{0} ", i));
            Console.WriteLine(string.Empty);

            Console.WriteLine("Graph - DFS");
            g.DFS(2, (i) => Console.Write("{0} ", i));
            Console.WriteLine(string.Empty);

            Graph g1 = new Graph(9);
            List<List<int>> g2 = new List<List<int>>() {
                new List<int>() { 0, 4, 0, 0, 0, 0, 0, 8, 0},
                new List<int>() { 4, 0, 8, 0, 0, 0, 0, 11, 0},
                new List<int>() { 0, 8, 0, 7, 0, 4, 0, 0, 2},
                new List<int>() { 0, 0, 7, 0, 9, 14, 0, 0, 0},
                new List<int>() { 0, 0, 0, 9, 0, 10, 0, 0, 0},
                new List<int>() { 0, 0, 4, 14, 10, 0, 2, 0, 0},
                new List<int>() { 0, 0, 0, 0, 0, 2, 0, 1, 6},
                new List<int>() { 8, 11, 0, 0, 0, 0, 1, 0, 7},
                new List<int>() { 0, 0, 2, 0, 0, 0, 6, 7, 0}
            };

            for (int i = 0; i < g2.Count; i++)
            {
                for (int j = 0; j < g2[i].Count; j++)
                {
                    if (g2[i][j] > 0)
                    {
                        g1.AddEdge(i, j, g2[i][j]);
                    }
                }
            }

            g1.PrintDistance(g1.Dijakstra(0), 0);
            Console.WriteLine(string.Empty);

            Console.WriteLine("Binary Search");
            int[] arr = new int[] { 1,2,3,4,5,6,7,8,9,10};
            foreach(int i in new int[]{-5, 1, 5,8, 0, 10, 11})
            {
                Console.WriteLine("Position of {0} = {1}", i, Search.BinarySearch(arr, i));
            }

            Console.WriteLine("Binary Search Next greatest - 1");
            int[] arr2 = new int[] { 100, 50, 40, 20, 10 };
            foreach (int i in new int[] { 5, 25, 50, 120 })
            {
                Console.WriteLine("Position of {0} = {1}", i, Search.BinarySearchNextGreatest(arr2, i));
            }

            Console.WriteLine("Binary Search Next greatest - 2");
            int[] arr3 = new int[] { 100, 90, 80, 75, 60 };
            foreach (int i in new int[] { 50, 65, 77, 90, 102 })
            {
                Console.WriteLine("Position of {0} = {1}", i, Search.BinarySearchNextGreatest(arr3, i));
            }

            Console.WriteLine("Trie");
            Trie t = new Trie();
            List<string> keysToInsert = new List<string>() { "microsoft", "google", "micro", "face", "facebook" };
            List<string> keysThatDoestExist = new List<string>() { "amazon", "apple", "facebo", "microsofts" };
            keysToInsert.ForEach(key => t.Insert(key));
            keysToInsert.ForEach(key =>
            {
                if (!t.Exists(key))
                {
                    Console.WriteLine("[failure] Expected key: {0} not found", key);
                }
                else
                {
                    Console.WriteLine("[success] Expected key: {0} found", key);
                }
            });

            keysThatDoestExist.ForEach(key =>
            {
                if (!t.Exists(key))
                {
                    Console.WriteLine("[success] Not Expected key: {0} not found", key);
                }
                else
                {
                    Console.WriteLine("[failure] Not Expected key: {0} found", key);
                }
            });

            Console.ReadKey();
        }
    }
}