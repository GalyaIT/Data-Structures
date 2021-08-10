namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;
        
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._top;
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

        public T Peek()
        {
            this.EnsureNotEmpty();
            return this._top.Item;
        }

        public T Pop()
        {
            this.EnsureNotEmpty();
            var topNodeItem = this._top.Item;
            var newTop = this._top.Next;
            this._top.Next = null;
            this._top = newTop;
            this.Count--;
            return topNodeItem;
        }

        public void Push(T item)
        {
            var newNode = new Node<T>(item);          
            newNode.Next = this._top;
            this._top = newNode;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._top;
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