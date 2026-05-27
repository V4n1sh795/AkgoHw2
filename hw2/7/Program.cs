using System.Security.Cryptography.X509Certificates;

class Programm
{
    public static void FullUp(ref int[] tree, int N)
    {
        for(int i = N - 1; i > 0; i--)
        {
            tree[i] = tree[2 * i] + tree[2 * i + 1];
        }
    }

    public static void Update(ref int[] tree, int index, int new_mean, int N)
    {
        int pos = index + N;
        tree[pos] = new_mean;
        for(pos /= 2; pos >= 1; pos /=2)
        {
            tree[pos] = tree[2 * pos] + tree[2 * pos + 1];
        }
    }

    public static int QuerySum(ref int[] tree, int l, int r, int N)
    {
        int res = 0;
        l += N;
        r += N;
        
        while (l < r)
        {
            if ((l & 1) == 1) res += tree[l++];
            if ((r & 1) == 1) res += tree[--r];
            l /= 2;
            r /= 2;
        }
        
        return res;
    }
    public static void Main()
    {
        int[] inp = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int N = inp[0], M =  inp[1];
        int[] tree = new int[N * 2];

        for(int i = 0; i < N; i++)
        {
            tree[N+i] = int.Parse(Console.ReadLine());
        }
        FullUp(ref tree, N);
        for(int i = 0; i < M; i++)
        {
            inp = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int status = inp[0], first = inp[1], second = inp[2];
            if (status == 1)
            {
                Console.WriteLine(QuerySum(ref tree, first-1, second, N));
            }
            else
            {
                Update(ref tree, first-1, second, N);
            }
        }
    }
}