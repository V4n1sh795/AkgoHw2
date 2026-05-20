class Program
{
    public static void Main()
    {
        int k = Convert.ToInt32(Console.ReadLine());
        int max = 0;
        int[] ar = new int[10];
        for(int i = 0; i < 4; i++)
        {
            string? input = Console.ReadLine();
            for (int j = 0; j < 10; j++)
            {
                char ch = (char)('0' + j);
                ar[j] = ar[j] + input.Count(ch);
            }
        }
        for(int i = 0; i < ar.Length; i++)
        {
            if ((ar[i] <= k*2) && (ar[i] != 0))
            {
                max++;
            }
        }
        Console.WriteLine(max);
    }
}