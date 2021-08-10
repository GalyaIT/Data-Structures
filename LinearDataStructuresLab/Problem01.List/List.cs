namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.GrowIfNessesary();
            this._items[Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }


        public int IndexOf(T item)
        {
            var index = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return index = i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.GrowIfNessesary();


            for (var i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }
            this._items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    RemoveAt(IndexOf(item));                  
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            for (int i = index; i < this.Count-1; i++)
            {
                this._items[i] = this._items[i + 1];
            }
            this._items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            =>  this.GetEnumerator();


        private void GrowIfNessesary()
        {
            if (this.Count == this._items.Length)
            {
                this._items = this.Grow();
            }
        }


        private T[] Grow()
        {
            var newArray = new T[this.Count * 2];
            Array.Copy(this._items, newArray, this._items.Length);
            return newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

    }
}