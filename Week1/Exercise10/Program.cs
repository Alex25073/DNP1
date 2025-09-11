namespace Exercise10
{
    class Program
    {
        static int bigDiff(int[] arr)
        {
            int max = arr[0];
            int min = arr[0];

            foreach (int num in arr)
            {
                if (num > max)
                {
                    max = num;
                }
                if (num < min)
                {
                    min = num;
                }
            }

            return max - min;

        }

        static void Main(string[] args)
        {
            int[] arr = { 10, 3, 5, 6 };
            int result = bigDiff(arr);
            System.Console.WriteLine(result); 
        }
    }
}