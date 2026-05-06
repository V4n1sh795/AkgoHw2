class Programm
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var signatures = new HashSet<string>();
        int[] freq = new int[26];

        for (int i = 0; i < n; i++)
        {
            string word = Console.ReadLine();
            Array.Clear(freq, 0, 26);

            foreach (char c in word)
            {
                freq[(int)c - (int)'A']++;
            }
            signatures.Add(string.Join("", freq));
        }

        Console.WriteLine(signatures.Count);
    }
}