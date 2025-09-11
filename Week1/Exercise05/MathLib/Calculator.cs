namespace MathLib
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        public int Compare(int x, int y)
        {
            if (x > y) return x;
            else return y;
        }
    }
}