using System.Reflection.Metadata;

class Program
{
    public class City
    {
        public string name;
        public static List<KeyValuePair<string, long>> ListOfBillioner = new List<KeyValuePair<string, long>>();
        public long Sum()
        {
            long sum = 0;
            foreach(var item in ListOfBillioner)
            {
                sum += item.Value;
            }
            return sum;  
        }
        public void AddElemToList(KeyValuePair<string, long> elem)
        {
            ListOfBillioner.Add(elem);
        }
        public void DeleteElem(KeyValuePair<string, long> elem)
        {
            ListOfBillioner.Remove(elem);
        }
        public List<KeyValuePair<string, long>> GetList() => ListOfBillioner;
        
        public City(string name, KeyValuePair<string, long> elem)
        {
            this.name = name;
            ListOfBillioner.Add(elem);
        }
        public KeyValuePair<string, long> FindBillionare(string name)
        {

            return ListOfBillioner.Find(kvp => kvp.Key == name);
        }
        public void DeleteBillionare(KeyValuePair<string, long> elem) => ListOfBillioner.Remove(elem);
    }
    public static City GetMost(List<City> cities)
    {
        City buisnes = cities[0];
        foreach(var elem in cities)
        {
            if(elem.Sum() > buisnes.Sum())
            {
                buisnes = elem;
            }
        }
        return buisnes;
    }
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<City> CityList = new List<City>();
        List<KeyValuePair<string, int>> city_day = new List<KeyValuePair<string, int>>();
        for(int i = 0;i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            string city = input[1];
            long dollars = long.Parse(input[2]);
            if(!CityList.Exists(c => c.name == city))
                CityList.Add(new City(city, new KeyValuePair<string, long>(name, dollars)));
            else
            {
                City c1 = CityList.Find(c => c.name == city);
                c1.AddElemToList(new KeyValuePair<string, long>(name, dollars));
            }   
        }
        string[] inp = Console.ReadLine().Split();
        int days = int.Parse(inp[0]);
        int redirection = int.Parse(inp[1]);

        List<City> CityListCopy = new List<City>(CityList);

        for(int i = 0; i < redirection; i++)
        {
            string[] input = Console.ReadLine().Split();
            int day = int.Parse(input[0]);
            string name = input[1];
            string city_name = input[2];
            foreach(City City in CityList)
            {
                KeyValuePair<string, long> cash = City.FindBillionare(name);
                City.DeleteBillionare(cash);
                if (CityListCopy.Exists(c => c.name == city_name))
                {
                    City toAdd = CityListCopy.Find(c => c.name == city_name);
                    toAdd.AddElemToList(cash);
                    CityListCopy.Add(toAdd);
                }
                else
                    CityListCopy.Add(new City(city_name, cash));

            }
            city_day.Add(new KeyValuePair<string, int>(GetMost(CityListCopy).name, day));
            CityList = CityListCopy;
            CityListCopy.Clear();
        }
        Console.WriteLine("result");
        foreach(var elem in city_day)
        {
            Console.WriteLine($"{elem.Key} {elem.Value}");
        }
    } 
}