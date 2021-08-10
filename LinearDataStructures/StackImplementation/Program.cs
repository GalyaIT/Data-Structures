using System;
using System.Collections.Generic;

namespace StackImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine(stack.Peek());


            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine("This is a CoolStack:");

            CoolStack<int> coolStack = new CoolStack<int>();

            for (int i = 0; i < 10; i++)
            {
                coolStack.Push(i);
            }

            Console.WriteLine(coolStack.Peek());


            while (coolStack.Count > 0)
            {
                Console.WriteLine(coolStack.Pop());
            }
        }
    }
}

