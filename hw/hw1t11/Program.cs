class Program
{
    public static void Main()
    {
        int lenght = Convert.ToInt32(Console.ReadLine());
        int toFind = Convert.ToInt32(Console.ReadLine());
        string[] inp = Console.ReadLine().Split();
        int[] arr = new int[lenght];
        for(int i = 0; i < inp.Length; i++)
        {
            arr[i] = int.Parse(inp[i]);
        }

        int left = 0;
        int right = lenght - 1;
        while(left <= right)
        {
            int mid = left + (right - left) / 2;
            if(arr[mid] == toFind)
            {
                Console.WriteLine(mid);
                break;
            }
            else if (arr[left] <= arr[mid])
            {
                if (arr[left] <= toFind && toFind < arr[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            else 
            {
                if (arr[mid] < toFind && toFind <= arr[right])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
        }
    }
}