namespace Exercise08
{
    class Program
    {
        static String makeOutWord(String outStr, String word)
        {
            String firstPart = outStr.Substring(0, 2);
            String secondPart = outStr.Substring(2, 2);
            return firstPart + word + secondPart;
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine(makeOutWord("<<>>", "Yay"));      
            System.Console.WriteLine(makeOutWord("<<>>", "WooHoo"));  
            System.Console.WriteLine(makeOutWord("[[]]", "word"));     
        }
    }
}