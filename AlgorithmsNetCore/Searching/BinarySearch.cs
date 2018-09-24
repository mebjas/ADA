using System;

namespace Algorithms
{
    public partial class Search : Helper
    {
        private static Func<int, int, int> DefaultComparator = (a, b) =>
        {
            return (a > b) ? 1 : -1;
        };

        public static int BinarySearch(int[] haystack, int needle, Func<int, int, int> comparator = null)
        {
            return BinarySearch(haystack, needle, 0, haystack.Length - 1, (comparator == null) ? DefaultComparator : comparator);
        }

        private static int BinarySearch(int[] haystack, int needle, int low, int high, Func<int, int, int> comparator)
        {
            int middle = (low + high) / 2;
            if (haystack[middle] == needle)
            {
                return middle;
            }

            if (middle == low && middle == high)
            {
                return -1;
            }

            if (comparator(haystack[middle], needle) > 0)
            {
                return BinarySearch(haystack, needle, low, middle - 1, comparator);
            }
            else
            {
                return BinarySearch(haystack, needle, middle + 1, high, comparator);
            }
        }
    }
}
