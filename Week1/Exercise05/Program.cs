using System;
using MathLib;

namespace Exercise05
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            Console.WriteLine(calculator.Add(5, 10));
            Console.WriteLine(calculator.Add(new int[] { 1, 2, 3, 4, 5 }));

            string x = Console.ReadLine();
            string y = Console.ReadLine(); 
            Console.WriteLine(calculator.Compare(int.Parse(x), int.Parse(y)));
        }
    }
}