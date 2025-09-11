using System;

namespace Exercise04
{
    class Program
    {
        static void PrintevenNumber(int x)
        {
            for (int i = 0; i < x; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void PrintOddNumbers(int x)
        {
            for (int i = 0; i < x; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void DivisibledBy(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                if (i % y == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Even numbers:");
            PrintevenNumber(10);
            Console.WriteLine("Odd numbers:");
            PrintOddNumbers(10);
            Console.WriteLine("Divisible by 3:");
            DivisibledBy(10, 3);
        }
    }
}