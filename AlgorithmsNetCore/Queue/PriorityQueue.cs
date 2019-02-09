using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class PriorityQueueNode : IComparable, ICloneable
    {
        public int Data;
        public int Priority;

        public int CompareTo(object otherNode)
        {
            if (!(otherNode is PriorityQueueNode))
            {
                throw new InvalidOperationException("only PriorityQueueNode supported");
            }

            if (this.Priority == ((PriorityQueueNode)otherNode).Priority) return 0;
            return this.Priority > ((PriorityQueueNode)otherNode).Priority ? 1 : -1;
        }

        public object Clone()
        {
            return new PriorityQueueNode()
            {
                Data = this.Data,
                Priority = this.Priority
            };
        }
    }

    public class PriorityQueue : IQueue<PriorityQueueNode> 
    {
        private MaxHeap<PriorityQueueNode> maxHeap = new MaxHeap<PriorityQueueNode>();

        public void Enqueue(PriorityQueueNode node)
        {
            this.maxHeap.Insert(node);
        }
        public void Enqueue(int data, int priority)
        {
            this.maxHeap.Insert(new PriorityQueueNode() { Data = data, Priority = priority });
        }

        public PriorityQueueNode Dequeue()
        {
            if (this.maxHeap.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return this.maxHeap.RemoveMax();
        }

        public PriorityQueueNode Peek()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            return this.maxHeap.Count == 0;
        }

        public int Count
        {
            get
            {
                return this.maxHeap.Count;
            }
        }
    }
}
