using System;
using System.Linq;

class Program
{

    static void Main()
    {
        Console.WriteLine((from u in Console.ReadLine().ToArray()
                           group u by u into gg
                           orderby gg.Count() descending
                           select gg.Key).ToList()[0]);
    }
}