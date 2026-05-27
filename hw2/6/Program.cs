class Programm
{
    static bool CanSplit(int[] chapters, int K, int limit)
    {
        int volumes = 1;
        int currentPages = 0;

        foreach (int pages in chapters)
        {
            if (currentPages + pages > limit)
            {
                volumes++;       
                currentPages = pages;
            }
            else
            {
                currentPages += pages;
            }
        }

        return volumes <= K;
    }
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] pages = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int K = int.Parse(Console.ReadLine());
        int left = pages.Max();
        int right = pages.Sum();
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            
            if (CanSplit(pages, K, mid))
                right = mid;      
            else
                left = mid + 1;   
        }
        Console.WriteLine(left);
}
}