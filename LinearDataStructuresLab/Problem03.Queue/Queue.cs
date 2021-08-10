namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _last;
        public Queue()
        {
            this._head = null;
            this.Count = 0;
        }
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._head;
            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();
            var oldHead = this._head;
            this._head = this._head.Next;
            if (this._head == null)
            {
                this._last = null;
            }

            Count--;

            return oldHead.Item;
        }

        public void Enqueue(T item)
        {
            Node<T> newLast = new Node<T>(item);        
           
            if (this._last == null)
            {
                this._last = newLast;
                this._head = newLast;
            }
            else
            {
                this._last.Next = newLast;
                this._last = newLast;

            }
            Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();
            return this._head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private bool EnsureNotEmpty()
        {
            if (Count > 0)
            {
                return true;
            }
            throw new InvalidOperationException();
        }
    }
}