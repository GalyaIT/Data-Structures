namespace LinkedList
{
    public class Node<T>
    {
        //recurcive data structure
        public Node(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}
