namespace _04._12._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            Dictionary<int, int> gameNumbers = new Dictionary<int, int>();
            string input;
            int final=0;
            int gN=1;
            while ((input = Console.ReadLine()) != ""){
                gameNumbers.Add(gN, 1);
                gN++;
                list.Add(input.Split(':')[1]);
            }

            gN = 1;
            foreach (string line in list)
            {
                int numberOfScratches = gameNumbers[gN];
                if(numberOfScratches == 1)
                {
                    Console.WriteLine(gN);
                }
                var numbers = line.Split('|');
                var winning = numbers[0].Replace("  "," ").Trim();
                var yours = numbers[1].Replace("  ", " ").Trim();
                int winningsCount = 0;
                int sum = 1;
                List<int> winningNumbers = new List<int>();
                foreach (string i in winning.Split(" ")) {
                    winningNumbers.Add(int.Parse(i));
                }
                List<int> yourNumbers = new List<int>();
                foreach (string i in yours.Split(" "))
                {
                    yourNumbers.Add(int.Parse(i));
                }
                yourNumbers.ForEach(i =>
                {
                    if (winningNumbers.Contains(i))
                        winningsCount++;
                });
                if (winningsCount > 0)
                   for (int i = 1; i <= winningsCount; i++)
                   {
                        gameNumbers[gN + i] += numberOfScratches;
                   }
                else
                {
                    //Console.WriteLine(gN+" "+numberOfScratches);
                }
                gN++;
            }
            int zs = 0;
            foreach (int item in gameNumbers.Values)
            {
                Console.WriteLine("key: " + (zs++) + " value: " + item);
                final += item;
            }


            Console.WriteLine(final);
            
        }
    }
}