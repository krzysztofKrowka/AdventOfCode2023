namespace _03._133232._2023
{
    class Number
    {
        public int x;
        public int y; 
        public int value;
        public bool read;
        public Number(int x, int y, int value)
        {
            this.y = y; 
            this.x = x; 
            this.value = value;
            this.read = false;
        }
    }
    class FullNumber
    {
        public string x;
        public int y;
        public int value;
        public string special;
        public string specialCoordinates;
        public FullNumber(string x, int y, int value)
        {
            this.y = y;
            this.x = x;
            this.value = value;
        }
    }
    class Gear
    {
        public int count;
        public List<int> values;        
        public Gear()
        {
            values = new List<int>();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> list = new List<List<string>>();
            List<Number> numbers =new List<Number>();
            List<FullNumber> fullNumbers = new List<FullNumber>();
            int pom;
            int finalSum = 0;
            string input;
            int counter = 0;
            
            while((input = Console.ReadLine()) != "") { 
                list.Add(new List<string>());
                foreach(var item in input) {
                    list[counter].Add(item.ToString());                 
                }
                counter++;
            }
            
            counter = 0;
            
            foreach(var item in list)
            {
                int x = 0;
                foreach(var element in item)
                {
                    try
                    {
                        numbers.Add(new Number(x,counter, int.Parse(element)));
                    }
                    catch { }
                    x++;
                }
                counter++;
            }
            
            counter = -1;
            
            foreach (Number number in numbers)
            {
                counter++;
                if(number.read == true)
                    continue;
                int numberLength = 1;
                for(int i = 1; i<5;i++)
                    try
                    {
                        int.Parse(list[number.y][number.x + i]);
                        numberLength++;
                    }
                    catch { break; }
                int finalValue = 0;
                for (int i = 0; i < numberLength; i++)
                {

                    finalValue += int.Parse(list[number.y][number.x + i]) * (int)Math.Pow(10, numberLength - 1 - i);
                    numbers[counter + i].read = true;
                }
                string xRange = number.x + "-" + (number.x + numberLength - 1);

                fullNumbers.Add(new FullNumber(xRange, number.y, finalValue));
            }
            int sum = 0;
            foreach (FullNumber fullNumber in fullNumbers)
            {
                sum+=fullNumber.value;
                //Console.WriteLine("X: " + fullNumber.x + " Y: " + fullNumber.y + " Value: " + fullNumber.value);
            }
            Console.WriteLine("FullNumbers full sum: "+sum);
            Console.WriteLine("tryparse: "+("@" != "." && int.TryParse("@",out pom)==false));

            foreach (FullNumber fullNumber in fullNumbers)
            {
                bool part = false;
                var range = fullNumber.x.Split('-');
                for(int i = int.Parse(range[0]); i <= int.Parse(range[1])+2; i++)
                {
                    try
                    {
                        if (list[fullNumber.y - 1][i -1] != "." && int.TryParse(list[fullNumber.y - 1][i - 1], out pom) == false)
                        {
                            part = true;
                            fullNumber.special = list[fullNumber.y - 1][i - 1];
                            fullNumber.specialCoordinates = fullNumber.y - 1+"/"+(i-1);
                        }
                    }catch { }
                    try
                    {
                        if (list[fullNumber.y][i - 1] != "." && int.TryParse(list[fullNumber.y][i - 1], out pom) == false)
                        {
                            part = true;
                            fullNumber.special = list[fullNumber.y][i - 1];
                            fullNumber.specialCoordinates = fullNumber.y + "/" + (i - 1);
                        }
                    }
                    catch { }
                    try
                    {
                        if (list[fullNumber.y + 1][i - 1] != "." && int.TryParse(list[fullNumber.y + 1][i - 1], out pom) == false)
                        {
                            part = true;
                            fullNumber.special = list[fullNumber.y + 1][i - 1];
                            fullNumber.specialCoordinates = fullNumber.y + 1 + "/" + (i - 1);
                        }
                    }
                    catch { }
                }
                //Console.WriteLine(part);
                if (part)
                {
                    finalSum += fullNumber.value;
                    //Console.WriteLine("X: " + fullNumber.x + " Y: " + fullNumber.y + " Value: " + fullNumber.value);
                }
                else
                {
                   // Console.WriteLine("X: "+fullNumber.x+" Y: "+fullNumber.y+" Value: "+fullNumber.value);
                }
            }
            
            List<FullNumber> corrects = new List<FullNumber>();
            Dictionary<string, Gear> stars = new Dictionary<string, Gear>();
            foreach (FullNumber fullNumber in fullNumbers)
            {
                if(fullNumber.special == "*")
                    corrects.Add(fullNumber);
            }
            foreach(var correct in corrects)
            {
                if (stars.ContainsKey(correct.specialCoordinates))
                {
                    stars[correct.specialCoordinates].count++;
                    stars[correct.specialCoordinates].values.Add(correct.value);
                }
                else
                {
                    Gear gear = new Gear();
                    gear.values.Add(correct.value);
                    gear.count = 1;
                    stars.Add(correct.specialCoordinates, gear);
                }
            }
            finalSum = 0;
            foreach(var star in stars)
            {
                if(star.Value.count == 2)
                {
                    finalSum += star.Value.values[0] * star.Value.values[1];
                }
            }
            Console.WriteLine("HE");
            Console.WriteLine(finalSum);
        }
    }
}