namespace Exercise09
{
    class Program
    {
        static void nTwice(string str, int n)
        {
            string first = str.Substring(0, n);
            string last = str.Substring(str.Length - n, n);
            Console.WriteLine(first + last);
        }

        static void Main(string[] args)
        {
            nTwice("Hello", 2);  
            nTwice("Chocolate", 3);  
            nTwice("Chocolate", 1);  
        }
    }
}