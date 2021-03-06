using System;
using System.Text;
using LinkedList;

namespace QueueImplementation
{
    class CoolQueue<T>
    {
        private LinkedList<T> linkedList;
        public CoolQueue()
        {
            this.linkedList = new LinkedList<T>();
        }
        public int Count { get { return linkedList.Count; } }
        public void Enqueue(T element)
        {
            linkedList.AddLast(element);
        }

        public T Peek()
        {
            return linkedList.Head.Value;
        }
        public T Dequeue()
        {
            return linkedList.RemoveHead().Value;
        }
    }
}
