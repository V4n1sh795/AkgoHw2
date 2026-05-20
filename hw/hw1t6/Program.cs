using System.IO.Pipelines;

class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(" ");
        int n = Convert.ToInt32(input[0]);
        int m = Convert.ToInt32(input[1]);
        int mod = Convert.ToInt32(input[2]);
        int[] koef = new int[n+1]; 
        int[] means = new int[m]; 
        for (int i = n; i >= 0; i--)
        {
            koef[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < m; i++)
        {
            means[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Result");
        for (int i = 0; i < m; i++)
        {
            int res = 0;
            for (int j = 0; j < n+1; j++)
            {
                res += (int)(koef[j] * Math.Pow(means[i], j)); 
            }
            Console.WriteLine(res%mod);
        }
    }
}