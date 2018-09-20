namespace Algorithms
{
    /**
     * QuickSort
     * Best Case: Omega(NlogN)
     * Worst Case: O(N^2)
     */
    public class QuickSort: Helper
    {
        int[] data;
        int n;

        public QuickSort(int[] data, int n)
        {
            this.data = data.Clone() as int[];
            this.n = n;
        }

        public int[] Sort()
        {
            this.QuickSortAlgorithm(this.data, 0, this.n - 1);
            return this.data.Clone() as int[];
        }

        private void QuickSortAlgorithm(int []arr, int low, int high)
        {
            if (low < high)
            {
                int pvt = this.Pivot(arr, low, high);
                this.QuickSortAlgorithm(arr, low, pvt - 1);
                this.QuickSortAlgorithm(arr, pvt + 1, high);
            }
        }

        private int Pivot(int []arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    if (i != j)
                    {
                        this.Swap(arr, i, j);
                    }
                }
            }

            this.Swap(arr, i + 1, high);
            return i + 1;
        }

        private void Swap(int []arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}

/**
 * More references 
 * 1. QuickSort on linked list: https://www.geeksforgeeks.org/quicksort-on-singly-linked-list/
 */
