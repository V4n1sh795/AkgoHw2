using System;

class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(input[0]);
        int m = Convert.ToInt32(input[1]);
        int mod = Convert.ToInt32(input[2]);
        
        int[] koef = new int[n + 1]; 
        int[] means = new int[m]; 
        
        for (int i = n; i >= 0; i--)
        {
            koef[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < m; i++)
        {
            means[i] = Convert.ToInt32(Console.ReadLine());
        }
        // Gorner
        for (int i = 0; i < m; i++)
        {
            long res = 0;
            long x = means[i] % mod; 
            for (int j = n; j >= 0; j--)
            {
                res = (res * x + koef[j]) % mod;
            }
            
            Console.WriteLine(res);
        }
    }
}