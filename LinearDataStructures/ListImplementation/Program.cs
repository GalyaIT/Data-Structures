using System;

namespace ListImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            CoolList<int> list = new CoolList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i * 5);
                Console.WriteLine($"Internal Array Count is {list.InternalArrayCount}");
                Console.WriteLine($"List Count is {list.Count}");
            }
        }
    }
}
