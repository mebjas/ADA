namespace Algorithms
{
    public class HeapSort : Helper
    {
        int[] data;
        int n;

        public HeapSort(int[] data, int n)
        {
            this.data = data.Clone() as int[];
            this.n = n;
        }

        public int[] Sort()
        {
            for (int i = (this.n / 2 - 1); i >= 0; i--)
            {
                MaxHeapify(i, this.n);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                this.Swap(0, i);
                this.MaxHeapify(0, i);
            }

            return this.data.Clone() as int[];
        }

        private void MaxHeapify(int i, int n)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && this.data[l] > this.data[largest])
            {
                largest = l;
            }

            if (r < n && this.data[r] > this.data[largest])
            {
                largest = r;
            }

            if (largest != i)
            {
                this.Swap(largest, i);
                this.MaxHeapify(largest, n);
            }
        }

        private void Swap(int i, int j)
        {
            int tmp = this.data[i];
            this.data[i] = this.data[j];
            this.data[j] = tmp;
        }
    }
}
