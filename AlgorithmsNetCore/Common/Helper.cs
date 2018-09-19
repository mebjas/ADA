using System;

namespace Algorithms
{
    public class Helper
    {
        public static void PrintArray(int[] data, int n)
        {
            string d = "";
            for (int i = 0; i < n; i++)
            {
                d += data[i].ToString();
                if (i != n - 1)
                {
                    d += ", ";
                }
            }

            Console.WriteLine(d);
        }
    }
}
