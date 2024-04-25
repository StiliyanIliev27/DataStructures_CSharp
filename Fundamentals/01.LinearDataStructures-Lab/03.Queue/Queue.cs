using System.Collections;

namespace _03.Queue
{
    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }
            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }
            public Node(T element)
            {
                Element = element;
            }
        }

        private Node head;
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = head;

            while(current != null)
            {
                if(current.Element.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }
        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            var oldHead = head;
            head = oldHead.Next;
            Count--;

            return oldHead.Element;
        }

        public void Enqueue(T item)
        {
            if(head == null)
            {
                head = new Node(item);
                Count++;
                return;
            }

            var node = head;
            while(node.Next != null)
            {
                node = node.Next;
            }

            node.Next = new Node(item);
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;

            while(current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        public T Peek()
        {
            if(head == null)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            return head.Element;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
