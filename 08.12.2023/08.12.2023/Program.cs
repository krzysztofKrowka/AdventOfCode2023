using System.Numerics;

namespace _08._12._2023
{
    class RL
    {
        public string R;
        public string L;
        public RL(string R, string L)
        {
            this.R = R;
            this.L = L;
        }
    }

    internal class Program
    {
        public static BigInteger findLCM(BigInteger a, BigInteger b)
        {
            BigInteger num1, num2;

            if (a > b)
            {
                num1 = a;
                num2 = b;
            }
            else
            {
                num1 = b;
                num2 = a;
            }

            for (BigInteger i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }
        static void Main(string[] args)
        {
            Dictionary<string,RL> maps = new Dictionary<string,RL>();
            Dictionary<string,RL> As = new Dictionary<string,RL>();
            List<int> counts = new List<int>();
            List<string> RLs = new List<string>();
            string input = Console.ReadLine();
            foreach (var c in input)
            {
                RLs.Add(c.ToString());
            }
            Console.ReadLine();
            while((input = Console.ReadLine()) != "") {
                var split = input.Split(" ");
                var key = split[0];
                var l = split[2][1].ToString() + split[2][2].ToString() + split[2][3].ToString();
                var r = split[3][0].ToString() + split[3][1].ToString() + split[3][2].ToString();
                maps.Add(key, new RL(r.ToString(), l.ToString()));
                if (key[2] == 'A')
                    As.Add(key, new RL(r.ToString(), l.ToString()));
            }
            
            bool isZZZ = false;
            int count = 0;
            string pom = "AAA";
            foreach (var c in As)
            {
                count = 0;
                pom = c.Key;
                while (!isZZZ)
                {
                    foreach (var RL in RLs)
                    {
                        if (RL == "R")
                        {
                            pom = maps[pom].R;
                        }
                        else
                        {
                            pom = maps[pom].L;
                        }
                        count++;
                        if (pom[2] == 'Z')
                        {
                            isZZZ = true;
                            break;
                        }
                    }
                }
                isZZZ = false;
                counts.Add(count);
            }
            BigInteger final = 1;
            foreach(var c in counts)
            {
                final = findLCM(final,c);
            }
            Console.WriteLine(final);
        }
    }
}