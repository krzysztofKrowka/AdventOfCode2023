namespace _02._12._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                list.Add(line);
            }
            int sum = 0;
            foreach (string item in list)
            {
                //bool add = true;
                int index = item.IndexOf(':');
                int ID = int.Parse(item.Substring(5, index-5));
                var sections = item.Split(':');
                Console.WriteLine(sections[0]);
                var games = sections[1].Split(';');
                int power = 0;
                int lowestRed=0, lowestGreen=0, lowestBlue=0;
                foreach (var game in games) {
                    var numbers = game.Split(",");
                    
                    
                    foreach (var number in numbers)
                    {
                        if (number.Contains("red"))// && int.Parse(number.Substring(1, number.LastIndexOf(" ") - 1)) > 12)
                        {
                            int red = int.Parse(number.Substring(1, number.LastIndexOf(" ") - 1));
                            if (red > lowestRed)
                                lowestRed = red;
                            //add = false;
                        }
                        if (number.Contains("green"))// && int.Parse(number.Substring(1,number.LastIndexOf(" ")-1)) > 13)
                        {
                            int green = int.Parse(number.Substring(1, number.LastIndexOf(" ") - 1));
                            if (green > lowestGreen)
                                lowestGreen = green;
                            //add = false;
                        }
                        if (number.Contains("blue"))// && int.Parse(number.Substring(1, number.LastIndexOf(" ") - 1)) > 14)
                        {
                            int blue = int.Parse(number.Substring(1, number.LastIndexOf(" ") - 1));
                            if (blue > lowestBlue)
                                lowestBlue = blue;
                            //add = false;
                        }
                    }
                    
                }
                Console.WriteLine(lowestRed+" "+lowestGreen+" "+lowestBlue);
                sum += lowestRed * lowestGreen * lowestBlue;
                /*if (add)
                {
                    sum += ID;
                    Console.WriteLine(ID+": "+sum);
                }*/
            } 
            Console.WriteLine(sum);
        }
    }
}