namespace _04._12._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string hello = "s";
            int sum = 0;
            List<string> list = new List<string>();
            while ((hello = Console.ReadLine()) != "")
            {
                list.Add(hello);
            }
            int count = 0;
            foreach (string item in list)
            {   
                int i = 0;
                List<int> ints = new List<int>();
                foreach (char c in item)
                {
                    try
                    {
                        string name = item[i].ToString() + item[i + 1].ToString() + item[i + 2].ToString();
                        if (name == "one")
                            ints.Add(1);
                        else if (name == "two")
                            ints.Add(2);
                        else if (name == "six")
                            ints.Add(6);
                        name += item[i + 3].ToString();
                        if (name == "four")
                            ints.Add(4);
                        else if (name == "five")
                            ints.Add(5);
                        else if (name == "nine")
                            ints.Add(9);
                        name += item[i + 4].ToString();
                        if (name == "three")
                            ints.Add(3);
                        else if (name == "eight")
                            ints.Add(8);
                        else if (name == "seven")
                            ints.Add(7);
                    }
                    catch { }
                    try
                    {
                        int number = int.Parse(c.ToString());
                        ints.Add(number);
                    }
                    catch { }
                    i++;
                }
                Console.WriteLine(count++);
                sum += ints[ints.Count - 1] + ints[0] * 10;
            }
            Console.WriteLine(sum);

        }
    }
}