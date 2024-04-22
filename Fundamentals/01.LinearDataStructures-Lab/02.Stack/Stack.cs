using System.Collections;

namespace _02.Stack
{
    public class Stack<T> : IAbstractStack<T>
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

        private Node top;
        public int Count { get; private set; }

        public bool Contains(T item)
        {    
            if (top == null)
            {
                throw new InvalidOperationException();
            }
            
            var current = top;

            while (current != null)
            {
                if(current.Element.Equals(item))
                {                    
                    return true;  
                }

                current = current.Next;
            }

            return false;
        }
        public T Peek()
        {
            if(top == null)
            {
                throw new InvalidOperationException();
            }

            return top.Element;
        }

        public T Pop()
        {
            if(top == null)
            {
                throw new InvalidOperationException();
            }

            var oldTop = top;
            top = oldTop.Next;

            Count--;
            return oldTop.Element;
        }

        public void Push(T item)
        {
            var node = new Node(item, top);
            top = node;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = top;

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
