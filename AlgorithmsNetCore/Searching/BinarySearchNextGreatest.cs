namespace Algorithms
{
    public partial class Search
    {
        public static int BinarySearchNextGreatest(int[] arr, int needle)
        {
            return BinarySearchNextGreatest(arr, needle, 0, arr.Length - 1) + 1;
        }

        private static int BinarySearchNextGreatest(int[] haystack, int needle, int low, int high)
        {
            int middle = (low + high) / 2;
            if (haystack[middle] == needle)
            {
                return middle;
            }

            if (needle < haystack[middle])
            {
                if (middle == high || haystack[middle + 1] < needle)
                {
                    return middle + 1;
                }

                return BinarySearchNextGreatest(haystack, needle, middle + 1, high);
            }
            else
            {
                if (middle == low || haystack[middle - 1] > needle)
                {
                    return middle;
                }

                return BinarySearchNextGreatest(haystack, needle, low, middle - 1);
            }
        }
    }
}
