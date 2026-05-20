class Q<T>
{
    List<T> queue = new List<T>();
    List<KeyValuePair<char, int>> history = new List<KeyValuePair<char, int>>();
    public void Add(T elem)
    {
        queue.Add(elem);
        history.Add(new KeyValuePair<char, int>('A', queue.IndexOf(queue.Last())));
    }
    public void DeleteMin()
    {
        try
        {
            T min = queue.Min();
            queue.Remove(min);
            Console.WriteLine(min);
        }
        catch
        {
            Console.WriteLine("*");
        }
        history.Add(new KeyValuePair<char, int>('X', 0));
    }
    public void DeleteX(int x, T y)
    {
        queue[history[x].Value] = y; 
    }

}

class Program
{
    public static void Main()
    {
        Q<int> q = new Q<int>();
        int inp = int.Parse(Console.ReadLine());
        for(int i = 0; i < inp; i++)
        {
            string[] input = Console.ReadLine().Split();
            if(input[0] == "A")
            {
                q.Add(int.Parse(input[1]));
            }
            else if(input[0] == "X")
            {
                q.DeleteMin();
            }
            else if(input[0] == "D")
            {
                q.DeleteX(int.Parse(input[1]), int.Parse(input[2]));
            }
        }
    }
}