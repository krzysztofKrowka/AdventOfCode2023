using System.Numerics;

namespace _09._12._2023
{
    internal class Program
    {
        static bool Check(List<int> tab)
        {
            foreach (int i in tab)
            {
                if(i != 0)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string input;
            List<List<int>> lines = new List<List<int>>();
            while((input = Console.ReadLine()) != "") 
            {
                var line = new List<int>();
                var numbers = input.Split(' ');
                foreach(var n  in numbers)
                {
                    line.Add(int.Parse(n));
                }
                lines.Add(line);
            }

            BigInteger sum = 0;
            foreach(var line in lines) 
            {
                List<int> newLine = new List<int> { 1, 2 };
                List<List<int>> decreasingLines = new List<List<int>> { line };
                int lineCounter = 0;
                while (!Check(newLine))
                {
                    newLine = new List<int>();
                    int count = 0;
                    foreach (var n in decreasingLines[lineCounter])
                    {
                        if (count == 0)
                        {
                            count++;
                            continue;
                        }
                        newLine.Add(n - decreasingLines[lineCounter][count - 1]);
                        
                        count++;
                    }
                    decreasingLines.Add(newLine);
                    lineCounter++;
                }
                BigInteger pom = 1; ;
                decreasingLines.Reverse();
                lineCounter = 0;
                foreach(var dL in decreasingLines)
                {
                    if (lineCounter == 0)
                    {
                        lineCounter++;
                        //Part 1
                        //pom = decreasingLines[lineCounter][decreasingLines[lineCounter].Count - 1];
                        pom = decreasingLines[lineCounter-1][0];
                        continue;
                    }
                    //Part 1 
                    //pom = decreasingLines[lineCounter][decreasingLines[lineCounter].Count-1] - pom;
                    pom = decreasingLines[lineCounter][0] - pom;
                    lineCounter++;
                }
                //pom -= decreasingLines[1][0];

                sum += pom;
            }
            Console.WriteLine(sum);
        }
    }
}