class Programm
{
    // не дописано 18 аналогичная так что не вижу смысла писать
    
    public static void Main()
    {
        int rec = int.Parse(Console.ReadLine());
        int bse = (int)(rec/2);
        // string[] l = new string[Math.Pow(26.0, 4096.0)];
        for(int i = 0; i < rec; i++)
        {
            string[] input = Console.ReadLine().Split();
            string command = input[0];
            string key = input[1];
            string line = input[2];
            int hash = 0;
            for(int j = 0; j < key.Length; j++)
            {
                hash += key[j] - 'A';
                Console.WriteLine($"{key[j]} - {hash}"); 
            }
            int pos = hash % bse;
            Console.WriteLine(pos);
            // switch(command)
            // {
            //     case "ADD":
            //         l[pos] = line;
            //         break;
            //     case "DELETE":
            //         l[pos] = "";
            //         break;
            //     case "UPDATE":
            //         l[pos] = line;
            //         break;
            //     case "PRINT":
            //         Console.WriteLine(l[pos]);
            //         break;
            // }
        }
    }
}