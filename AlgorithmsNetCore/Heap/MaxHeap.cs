using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public interface ICloneable
    {
        object Clone();
    }

    class MaxHeap<T> where T : IComparable, ICloneable
    {
        private List<T> nodes = new List<T>();

        public int Count
        {
            get
            {
                return this.nodes.Count;
            }
        }

        public void Insert(T node)
        {
            if (this.nodes.Count == 0)
            {
                this.nodes.Add(node);
                return;
            }

            if (node.CompareTo(this.nodes[0]) > 0)
            {
                this.nodes.Add((T)this.nodes[0].Clone());
                this.nodes[0] = node;
            }
            else
            {
                this.nodes.Add(node);
            }
        }

        public T GetMax()
        {
            if (this.nodes.Count == 0)
            {
                throw new InvalidOperationException("Heap Empty");
            }

            return this.nodes[0];
        }

        public T RemoveMax()
        {
            if (this.nodes.Count == 0)
            {
                throw new InvalidOperationException("Heap Empty");
            }

            T node = (T)this.nodes[0].Clone();
            this.nodes[0] = this.nodes[this.nodes.Count - 1];
            this.nodes.RemoveAt(this.nodes.Count - 1);

            this.Heapify(0);

            return node;
        }

        private void Heapify(int n)
        {
            if (n >= this.nodes.Count)
            {
                return;
            }

            int largest = n;
            T largestNode = (T)this.nodes[n].Clone();
            int left = 2 * n + 1;
            int right = 2 * n + 2;
            if (left >= this.nodes.Count)
            {
                return;
            }

            T leftNode = (T)this.nodes[left].Clone();
            if (leftNode.CompareTo(largestNode) > 0)
            {
                largest = left;
            }

            if (right < this.nodes.Count)
            {
                T rightNode = (T)this.nodes[right].Clone();
                largestNode = (T)this.nodes[largest].Clone();
                if (rightNode.CompareTo(largestNode) > 0)
                {
                    largest = right;
                }
            }

            if (n != largest)
            {
                T node = (T)this.nodes[n].Clone();
                this.nodes[n] = (T)this.nodes[largest].Clone();
                this.nodes[largest] = node;
                this.Heapify(largest);
            }
        }
    }
}
