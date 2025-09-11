namespace Exercise07
{
    internal class Program
    {
        static void makeAbba(string a, string b)
        {
            Console.WriteLine($"{a}{b}{b}{a}");
        }

        static void Main(string[] args)
        {
            makeAbba("Hi", "Bye");
            makeAbba("Yo", "Alice");
            makeAbba("What", "Up");
        }
    }
}