using System.Numerics;

namespace _06._12._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var time = Console.ReadLine();
            var dist = Console.ReadLine();
            List<int> times = new List<int>();
            List<int> distances = new List<int>();
            string fT = "", fD = "";
            foreach (string t in time.Split(' '))
            {
                try
                {
                    int zsda = int.Parse(t);
                    fT += t;
                }
                catch { }
            }
            foreach (string d in dist.Split(' '))
            {
                try
                {
                    int zsda = int.Parse(d);
                    fD += d;
                }
                catch { }
            }

            BigInteger finalTime = BigInteger.Parse(fT);
            BigInteger finalDistance = BigInteger.Parse(fD);

            int counter = 0;
            int margin = 1;
            Console.WriteLine("finalTime: "+finalTime);
            Console.WriteLine("finalDistance: "+finalDistance);
            BigInteger distance = finalDistance;
            int winningCount = 0;
            BigInteger firstWinning = 0;
            BigInteger lastWinning = 0;
            for (BigInteger z = 1; z <= finalTime; z++)
            {
                if (z * (finalTime - z) > distance)
                {
                    firstWinning = z;
                    Console.WriteLine(firstWinning);
                    break;
                }
            }
            for (BigInteger z = finalTime; z >= 1; z--)
            {
                if (z * (finalTime - z) > distance)
                {
                    lastWinning = z;
                    Console.WriteLine(lastWinning);
                    break;
                }
            }
            Console.WriteLine("Final Answer: "+(lastWinning-firstWinning+1));
        }
    }
}