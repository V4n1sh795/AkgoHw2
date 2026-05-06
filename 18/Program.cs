class Programm
{
    public static void Main()
    {
        int rec = int.Parse(Console.ReadLine());
        int[] l = new int[rec];
        for(int i = 0 ; i < rec; i++)
        {
            l[i] = -1;
        }
        for (int i = 0; i < rec; i++)
        {
            string[] input = Console.ReadLine().Split();
            string command = input[0];
            int id = int.Parse(input[1]);
            switch(command)
            {
                case "get":
                    if (l[id % rec] < 0)
                        Console.WriteLine("None");
                    else
                        Console.WriteLine(l[id % rec]);
                    break;
                case "put":
                    if (l[id % rec] == -1)
                        l[id % rec] = int.Parse(input[2]);
                    else
                    {
                        l[id % rec] = int.Parse(input[2]);
                    }
                    break;
                case "delete":
                    if( l[id % rec] < 0)
                        Console.WriteLine("None");
                    else
                    {
                        Console.WriteLine(l[id % rec]);
                        l[id % rec] = -2;
                    }
                        
                    break;
            }
        }
    }
}