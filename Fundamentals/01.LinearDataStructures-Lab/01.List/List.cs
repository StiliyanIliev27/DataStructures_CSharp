﻿using System.Collections;

namespace _01.List
{
    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }
        public List(int capacity)
        {
            if(capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            items = new T[capacity];
        }
       
        public T this[int index] 
        {
            get
            {
                ValidateIndex(index);
                return items[index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            Grow();     
            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1 ? true : false;
        }

        public int IndexOf(T item)
        {
            for(int i = 0; i < Count; i++)
            {
                if (item!.Equals(items[i]))
                {
                    return i;
                }
            }
            
            return -1;
        }

        public void Insert(int index, T item)
        {   
            ValidateIndex(index);
            Grow();

            for(int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if(index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for(int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count - 1] = default!;
            Count--;
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Grow()
        {
            if (Count == items.Length)
            {
                T[] itemsCopy = new T[items.Length * 2];
                Array.Copy(items, itemsCopy, items.Length);
                items = itemsCopy;
            }
        }
        private void ValidateIndex(int index)
        {
            if(index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }
    }
}
