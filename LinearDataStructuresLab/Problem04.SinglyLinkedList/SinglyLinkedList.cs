namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _last;
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item, this._head);           
            this._head = newNode;
            this.Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            this.EnsureNotEmpty();
            return this._head.Item;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            var current = this._head;
            T lastElement = default;

            if (this.Count == 1)
            {
                return this._head.Item;
            }
            for (int i = 0; i < Count; i++)
            {
                lastElement = current.Item;
                current = current.Next;
            }
            
            return lastElement;          
        }

        public T RemoveFirst()
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

        public T RemoveLast()
        {
            this.EnsureNotEmpty();
            var current = this._head;
            T lastElement = default;
            Node<T> previous = null;

            if (this.Count == 1)
            {
                lastElement = this._head.Item;
                this._head = null;
            }
            else
            {
                for (int i = 0; i < this.Count; i++)
                {
                    previous = current;
                    current = current.Next;
                }

                if (previous != null)
                {
                    lastElement = previous.Item;
                    previous.Next = null;
                }
            }

            this.Count--;
            return lastElement;

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