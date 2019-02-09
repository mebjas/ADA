namespace Algorithms
{
    interface IQueue<T>
    {
        void Enqueue(T node);
        T Dequeue();
        T Peek();

        bool IsEmpty();

        int Count { get; }
    }
}
