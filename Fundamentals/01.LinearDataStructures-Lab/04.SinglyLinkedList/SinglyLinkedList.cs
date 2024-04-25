using System.Collections;

namespace _04.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IAbstractSinglyLinkedList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }
            public Node(T element)
            {
                Element = element;
            }
            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }
        }
        
        private Node head;
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item, head);
            head = node;
            Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            if(head == null)//Empty collection case
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            return head.Element;
        }

        public T GetLast()
        {
            if(head == null)//Empty collection case
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            var node = head;

            while(node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
        {
            if(head == null)//Empty collection case
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            var oldHead = head;
            head = oldHead.Next;

            Count--;
            return oldHead.Element;
        }

        public T RemoveLast()
        {
            if(head == null)//Empty collection case
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            var node = head;

            if(node.Next == null)//One element only in the collection case
            {
                var oldElement  = head.Element;
                head = null;
                Count--;
                return oldElement;
            }

            while(node.Next.Next != null)
            {
                node = node.Next;
            }

            var oldNode = node.Next;
            node.Next = null;
            Count--;
            return oldNode.Element;
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
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
