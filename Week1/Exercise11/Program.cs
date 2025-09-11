namespace Exercise11
{
    class Program
    {
        static int countClumps(int[] nums)
        {
            int clumps = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        clumps++;
                        i = j;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return clumps;
        }

        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 2, 3, 4, 4 };
            int result = countClumps(nums);
            System.Console.WriteLine(result);
        }
    }
}