using System;

class Program
{
    const ulong MOD_BIG = 4294967295UL;

    static void RadixSort(uint[] src, uint[] dst, int n)
    {
        uint[] input = src;
        uint[] output = dst;

        int[] cnt = new int[256];

        for (int shift = 0; shift < 32; shift += 8)
        {
            Array.Clear(cnt, 0, cnt.Length);

            for (int i = 0; i < n; ++i)
            {
                byte byteVal = (byte)((input[i] >> shift) & 0xFF);
                cnt[byteVal]++;
            }

            int sum = 0;
            for (int i = 0; i < 256; ++i)
            {
                int temp = cnt[i];
                cnt[i] = sum;
                sum += temp;
            }

            for (int i = 0; i < n; ++i)
            {
                byte byteVal = (byte)((input[i] >> shift) & 0xFF);
                output[cnt[byteVal]] = input[i];
                cnt[byteVal]++;
            }

            uint[] tempArray = input;
            input = output;
            output = tempArray;
        }

        if (input != src)
        {
            Array.Copy(input, src, n);
        }
    }

    static void Main()
    {
        string line = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(line)) return;
        
        string[] parts = line.Split();
        
        int N = int.Parse(parts[0]);
        uint K = uint.Parse(parts[1]);
        uint M = uint.Parse(parts[2]);
        uint L = uint.Parse(parts[3]);

        uint[] a = new uint[N];
        uint[] b = new uint[N];

        uint current = K;
        a[0] = current;

        for (int i = 1; i < N; ++i)
        {
            ulong nextVal = (ulong)current * M;
            nextVal %= MOD_BIG;
            nextVal %= L;
            current = (uint)nextVal;
            a[i] = current;
        }

        RadixSort(a, b, N);

        ulong sum = 0;
        for (int i = 0; i < N; i += 2)
        {
            sum += a[i];

            if (sum >= (ulong)L * 1000000UL)
            {
                sum %= L;
            }
        }

        sum %= L;

        Console.WriteLine(sum);
    }
}