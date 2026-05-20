using System;
using System.Collections.Generic;

class Program
{
    public static int Compare(Record rec1, Record rec2, int[] priority)
    {
        for(int i = 0; i < priority.Length; i++)
        {
            int colIndex = priority[i] - 1; // 1-based 0-based
            
            if(rec1.ak[colIndex] > rec2.ak[colIndex])
                return 1;
            if(rec1.ak[colIndex] < rec2.ak[colIndex])
                return 2;
        }
        return 0;
    }
    
    public struct Record
    {
        public string Name;
        public List<int> ak;
        
        public Record(string name, int k)
        {
            Name = name;
            ak = new List<int>(k);
        }
    }

    public static void Main()
    {
        string line = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(line))
            line = Console.ReadLine();
        int n = int.Parse(line.Trim());
        
        line = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(line))
            line = Console.ReadLine();
        int k = int.Parse(line.Trim());
        
        line = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(line))
            line = Console.ReadLine();
        string[] inp = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        
        List<Record> records = new List<Record>();
        int[] priority = new int[k]; 
        
        for(int i = 0; i < k; i++)
        {
            priority[i] = int.Parse(inp[i]);
        }
        
        for(int i = 0; i < n; i++)
        {
            line = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(line))
                line = Console.ReadLine();
            inp = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            
            Record record = new Record(inp[0], k);
            
            for(int j = 1; j <= k; j++)
            {
                record.ak.Add(int.Parse(inp[j]));
            }
            records.Add(record);
        }
        
        // Bubble sort
        for(int i = 0; i < n-1; i++)
        {
            for(int j = 0; j < n-i-1; j++)
            {
                if(Compare(records[j], records[j+1], priority) == 2)
                {
                    Record temp = records[j];
                    records[j] = records[j+1];
                    records[j+1] = temp;
                }
            }
        }
        
        foreach(Record rec in records)
        {
            Console.WriteLine(rec.Name);
        }
    }
}