namespace _02.Stack
{
    public interface IAbstractStack<T> : IEnumerable<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        bool Contains(T item);
        int Count { get; }  
    }
}
