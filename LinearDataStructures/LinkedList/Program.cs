using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Node<int> node1 = new Node<int>(1);
            //Node<int> node2 = new Node<int>(2);
            //Node<int> node3 = new Node<int>(3);
            //Node<int> node4 = new Node<int>(4);

            //node1.Next = node2;
            //node2.Next = node3;
            //node3.Next = node4;

            //var currentNode = node1;


            //while (currentNode!=null)
            //{
            //    Console.WriteLine(currentNode.Value);
            //    currentNode = currentNode.Next;
            //}

            //Console.WriteLine(node1.Next.Next.Next.Value);

            LinkedList<int> linkedList = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                linkedList.Add(i);
            }
            linkedList.RemoveHead();
            linkedList.RemoveHead();
            linkedList.RemoveHead();


            var currentNode = linkedList.Head;


            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }

        }
    }
}
   