namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - index - 1];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.ValidateLength();
            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }

            }
            return false;
        }

        public int IndexOf(T item)
        {          
            for (int i = this.Count-1; i >=0; i--)
            {
                if (this.items[i].Equals(item))
                {
                   return  this.Count - i - 1;                   
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.ValidateLength();
            for (int i = this.Count; i > this.Count-index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            this.items[this.Count-index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int indexToRemove = this.IndexOf(item);
            if (indexToRemove != -1)
            {
                this.RemoveAt(indexToRemove);
                return true;
            }
            else
            {
                return false;
            }

        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            int indexToRemove = this.Count - index - 1;
            for (int i = indexToRemove; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private void ValidateLength()
        {
            if (this.Count == this.items.Length)
            {
                this.items=Grow();
            }
        }
        private T[] Grow()
        {
            var newArray = new T[this.Count * 2];
            Array.Copy(this.items, newArray, this.items.Length);
            return newArray;
        }
    }
}