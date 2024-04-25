namespace _04.SinglyLinkedList
{
    public interface IAbstractSinglyLinkedList<T> : IEnumerable<T>
    {
        void AddFirst(T item);
        void AddLast(T item);
        T RemoveFirst();
        T RemoveLast();
        T GetFirst();
        T GetLast();
        int Count { get; }
    }
}
