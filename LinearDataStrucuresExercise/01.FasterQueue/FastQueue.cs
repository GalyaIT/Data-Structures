namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
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
            this.Count--;
            return oldHead.Item;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (Count == 0)
            {
                this._head = newNode;
                this._tail = newNode;

                // this._head = this._tail = newNode;

                this.Count++;
                return;
            }          
                this._tail.Next = newNode;
                this._tail = this._tail.Next;
                this.Count++;
            
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