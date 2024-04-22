namespace _03.Queue
{
    public interface IAbstractQueue<T> : IEnumerable<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
        bool Contains(T item);
        int Count { get; } 
    }
}
