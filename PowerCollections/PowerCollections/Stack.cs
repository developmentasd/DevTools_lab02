using System;
using System.Collections;
using System.Collections.Generic;

namespace PowerCollections
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] storage;

        public int Count { get; private set; } = 0;
        public int Capacity => storage.Length;

        public Stack(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException("Length should be above zero");
            storage = new T[capacity];
        }

        public void Push(T value)
        {
            if (Count >= Capacity)
                throw new InvalidOperationException("Stack is full");

            storage[Count++] = value;
        }

        public T Pop()
        {
            if (Count <= 0)
                throw new InvalidOperationException("Stack is empty");

            return storage[--Count];
        }

        public T Top()
        {
            if (Count <= 0)
                throw new InvalidOperationException("Stack is empty");

            return storage[Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return storage[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
