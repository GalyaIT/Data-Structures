using System;
using System.Collections.Generic;

namespace QueueImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            Console.WriteLine(queue.Peek());

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.WriteLine("This is a CoolQueue:");

            CoolQueue<int> coolQueue = new CoolQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                coolQueue.Enqueue(i);
            }

            Console.WriteLine(coolQueue.Peek());

            while (coolQueue.Count > 0)
            {
                Console.WriteLine(coolQueue.Dequeue());
            }
        }
    }
}

