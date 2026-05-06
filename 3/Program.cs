class Programm
{
    public static int GetMixCount(int[] set1, int[] set2)
    {
        int count = 0, p1 = 0, p2= 0;
        while (p1 < set1.Length && p2 < set2.Length)
        {
            if (set1[p1] == set2[p2]) {count++; p1++; p2++; }
            else if (set1[p1] < set2[p2]) p1++;
            else p2++;
        }
        return count;
    }
    public static void Main()
    {
        int maxCount = 0, count, N, M;
        string[] inp = Console.ReadLine().Split();
        N = int.Parse(inp[0]);
        M = int.Parse(inp[1]);
        int[][] sets = new int[N][];
        for(int i = 0; i < N; i++)
        {
            int[] pepe = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(pepe);
            sets[i] = pepe;
        }
        for(int i = 0; i < N; i++)
        {
            for(int j = i+1; j < N; j++)
            {
                count = GetMixCount(sets[i], sets[j]);
                if (count > maxCount)
                {
                    maxCount = count;
                }
            }
        }
        Console.WriteLine(maxCount);
    }
}