using System;

class Program
{
    public static int[] GetMoves(int[] beforeSort, int[] afterSort)
    {
        int[] result = new int[beforeSort.Length];
        for(int i = 0; i < beforeSort.Length; i++)
        {
            result[i] = Array.IndexOf(afterSort, beforeSort[i]);
        }
        return result;
    }
    
    public static void Main()
    {
        string[] inp = Console.ReadLine().Split();
        int n = int.Parse(inp[0]); 
        int m = int.Parse(inp[1]); 
        int[][] arr = new int[n][];
        int[][] res = new int[n][];
        

        for (int i = 0; i < n; i++)
        {
            arr[i] = new int[m];
            res[i] = new int[m];
        }

        // Read data
        for (int i = 0; i < n; i++)
        {
            string[] inp2 = Console.ReadLine().Split();
            
            for (int j = 0; j < m; j++)
            {
                arr[i][j] = int.Parse(inp2[j]);
            }
        }
        
        int[] notsorted = new int[m];
        Array.Copy(arr[0], notsorted, m);
        Array.Sort(arr[0]);
        
        Array.Copy(arr[0], res[0], m);
        
        int[] moves = GetMoves(notsorted, arr[0]);
        
        for(int i = 1; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                res[i][j] = arr[i][moves[j]];
            }
        }
        
        int[] firstElem = new int[n];
        for(int i = 0; i < n; i++)
        {   
            firstElem[i] = res[i][0];
        }
        
        notsorted = new int[n];
        Array.Copy(firstElem, notsorted, n);
        Array.Sort(firstElem);
        
        int[] moves2 = GetMoves(notsorted, firstElem);
        
        Console.WriteLine("moves 2");
        int[][] finalResult = new int[n][];
        for(int i = 0; i < n; i++)
        {
            finalResult[i] = new int[m];
        }
        
        for(int i = 0; i < n; i++)
        {
            Array.Copy(res[i], finalResult[moves2[i]], m);
        }
        
        foreach(int[] element in finalResult)
        {
            foreach(int elem in element)
            {
                Console.Write(elem + "\t");
            }
            Console.WriteLine();
        }
    }
}