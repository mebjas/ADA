namespace Algorithms
{

    /**
     * MergeSort
     * Best Case: Omega(NlogN)
     * Worst Case: O(NlogN)
     */ 
    public class MergeSort: Helper
    {
        int[] data;
        int n;

        public MergeSort(int[] data, int n)
        {
            this.data = data.Clone() as int[];
            this.n = n;
        }

        public int[] Sort()
        {
            this.MergeSortAlgorithm(this.data, 0, this.n - 1);
            return this.data.Clone() as int[];
        }

        private void MergeSortAlgorithm(int []arr, int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                this.MergeSortAlgorithm(arr, low, middle);
                this.MergeSortAlgorithm(arr, middle + 1, high);
                this.Merge(arr, low, middle, high);
            }
        }

        private void Merge(int []arr, int low, int middle, int high)
        {
            int i, j, k;
            int n1 = middle - low + 1;
            int n2 = high - middle;
            int []A = new int[n1], B = new int[n2];
            for (j = 0, i = low; i <= middle; i++, j++)
            {
                A[j] = arr[i];
            }

            for (j = 0, i = middle + 1; i <= high; i++, j++)
            {
                B[j] = arr[i];
            }

            j = 0;
            k = 0;
            i = low;
            while (j < n1 && k < n2)
            {
                if (A[j] <= B[k])
                {
                    arr[i++] = A[j++];
                }
                else
                {
                    arr[i++] = B[k++];
                }
            }

            while (j < n1)
            {
                arr[i++] = A[j++];
            }

            while (k < n2)
            {
                arr[i++] = B[k++];
            }
        }
    }
}
