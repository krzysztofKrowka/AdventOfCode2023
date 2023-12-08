using System.Numerics;

namespace _07._12._2023
{
    public class Hand
    {
        public string hand;
        public List<int> values;
        public Hand(string hand, List<int> values)
        {
            this.values = values;
            this.hand = hand;
        }
    }
    internal class Program
    {
        static public int Convert(string hand)
        {
            
            Dictionary<char,int> cards = new Dictionary<char,int>();
            int jokerCount = 0;
            foreach (char c in hand)
            {
                if(c == 'J')
                    jokerCount++;
                if (!cards.ContainsKey(c))
                    cards.Add(c,1);
                else
                    cards[c]++;
            }

            if (cards.Count == 1)
                return 7;
            if(cards.Count == 2)
            {
                if (cards.ContainsValue(4))
                {
                    if(jokerCount == 0)
                        return 6;
                    return 7;
                }
                if(jokerCount == 0)
                    return 5;
                return 7;
            }
            if(cards.Count == 3)
            {
                if (cards.ContainsValue(3)) {
                    if (jokerCount == 0)
                        return 4;
                    if (jokerCount == 1 || jokerCount == 3)
                        return 6;
                 }
                if (jokerCount == 0)
                    return 3;
                if (jokerCount == 1)
                    return 5;
                if (jokerCount == 2)
                    return 6;
            }
            if (cards.Count == 4)
            {
                if (jokerCount == 0)
                    return 2;
                return 4;
            }
            if (cards.Count == 5)
            {
                if (jokerCount == 0)
                    return 1;
                return 2;
            }
            return 0;
        }
        static void Main(string[] args)
        {
            Dictionary<string,int> pairs = new Dictionary<string,int>();

            string input;
            while ((input = Console.ReadLine()) != "")
            {
                string[] split = input.Split(' ');
                pairs.Add(split[0], int.Parse(split[1]) );
            }
            Dictionary<string,int> pairsWithRanks = new Dictionary<string,int>();
            foreach (var hand in pairs)
            {
                pairsWithRanks.Add(hand.Key, Convert(hand.Key));
            }
            var orderedPairs = pairsWithRanks.OrderBy(x => x.Value);
            var firstRank = orderedPairs.Where(x => x.Value == 1);
            var secondRank = orderedPairs.Where(x => x.Value == 2);
            var thirdRank = orderedPairs.Where(x => x.Value == 3);
            var fourthRank = orderedPairs.Where(x => x.Value == 4);
            var fifthRank = orderedPairs.Where(x => x.Value == 5);
            var sixthRank = orderedPairs.Where(x => x.Value == 6);
            var seventhRank = orderedPairs.Where(x => x.Value == 7);
            var zero = orderedPairs.Where(x => x.Value == 0);
            var firstRankOrdered = new List<Hand>(firstRank.Count());
            int count = 0;
            foreach (var pair in firstRank)
            {
                var tab = new List<int>(5);
                bool added = false;
                foreach(char c in pair.Key)
                {
                    try
                    {
                        tab.Add(int.Parse(c.ToString()));
                    }
                    catch
                    {
                        if (c == 'T')
                            tab.Add(10);
                        if (c == 'J')
                            tab.Add(1);
                        if (c == 'Q')
                            tab.Add(12);
                        if (c == 'K')
                            tab.Add(13);
                        if (c == 'A')
                            tab.Add(14);
                    }
                }
                
                if (count == 0)
                    {
                        firstRankOrdered.Add(new Hand(pair.Key, tab));
                        count++;
                        added = true;
                        continue;
                    }
                int listCounter = 0;
                
                foreach (var hand in firstRankOrdered)
                {
                    if (tab[0] > hand.values[0])
                    {
                        firstRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added=true;
                        break;
                    }
                    if (tab[0] < hand.values[0])
                    {
                        listCounter++;
                        continue;
                    }
                    
                    if (tab[1] > hand.values[1])
                    {
                        firstRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        added = true;
                        listCounter++;
                        break;
                    }
                    if (tab[1] < hand.values[1])
                    {
                        listCounter++;
                        continue;
                    }
                    
                    if (tab[2] > hand.values[2])
                    {
                        firstRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[2] < hand.values[2])
                    {
                        listCounter++;
                        continue;
                    }
                    
                    if (tab[3] > hand.values[3])
                    {
                        firstRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[3] < hand.values[3])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[4] > hand.values[4])
                    {
                        firstRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[4] < hand.values[4])
                    {
                        listCounter++;
                        continue;
                    }
                }
                if(!added)
                    firstRankOrdered.Add(new Hand(pair.Key, tab));
            }
            firstRankOrdered.Reverse();

            var secondRankOrdered = new List<Hand>();
            count = 0;
            foreach (var pair in secondRank)
            {
                var tab = new List<int>(5);
                bool added = false;
                foreach (char c in pair.Key)
                {
                    try
                    {
                        tab.Add(int.Parse(c.ToString()));
                    }
                    catch
                    {
                        if (c == 'T')
                            tab.Add(10);
                        if (c == 'J')
                            tab.Add(1);
                        if (c == 'Q')
                            tab.Add(12);
                        if (c == 'K')
                            tab.Add(13);
                        if (c == 'A')
                            tab.Add(14);
                    }
                }

                if (count == 0)
                {
                    secondRankOrdered.Add(new Hand(pair.Key, tab));
                    count++;
                    continue;
                }
                int listCounter = 0;

                foreach (var hand in secondRankOrdered)
                {
                    if (tab[0] > hand.values[0])
                    {
                        secondRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[0] < hand.values[0])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[1] > hand.values[1])
                    {
                        secondRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[1] < hand.values[1])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[2] > hand.values[2])
                    {
                        secondRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[2] < hand.values[2])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[3] > hand.values[3])
                    {
                        secondRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[3] < hand.values[3])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[4] > hand.values[4])
                    {
                        secondRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[4] < hand.values[4])
                    {
                        listCounter++;
                        continue;
                    }
                }
                if(!added)
                    secondRankOrdered.Add(new Hand(pair.Key, tab));
            }
            secondRankOrdered.Reverse();

            var thirdRankOrdered = new List<Hand>();
            count = 0;
            foreach (var pair in thirdRank)
            {
                var tab = new List<int>(5);
                bool added = false;
                foreach (char c in pair.Key)
                {
                    try
                    {
                        tab.Add(int.Parse(c.ToString()));
                    }
                    catch
                    {
                        if (c == 'T')
                            tab.Add(10);
                        if (c == 'J')
                            tab.Add(1);
                        if (c == 'Q')
                            tab.Add(12);
                        if (c == 'K')
                            tab.Add(13);
                        if (c == 'A')
                            tab.Add(14);
                    }
                }

                if (count == 0)
                {
                    thirdRankOrdered.Add(new Hand(pair.Key, tab));
                    count++;
                    continue;
                }
                int listCounter = 0;

                foreach (var hand in thirdRankOrdered)
                {
                    if (tab[0] > hand.values[0])
                    {
                        thirdRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[0] < hand.values[0])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[1] > hand.values[1])
                    {
                        thirdRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[1] < hand.values[1])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[2] > hand.values[2])
                    {
                        thirdRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[2] < hand.values[2])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[3] > hand.values[3])
                    {
                        thirdRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[3] < hand.values[3])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[4] > hand.values[4])
                    {
                        thirdRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[4] < hand.values[4])
                    {
                        listCounter++;
                        continue;
                    }
                }
                if (!added)
                    thirdRankOrdered.Add(new Hand(pair.Key, tab));
            }
            thirdRankOrdered.Reverse();

            var fourthRankOrdered = new List<Hand>();
            count = 0;
            foreach (var pair in fourthRank)
            {
                var tab = new List<int>(5);
                bool added = false;
                foreach (char c in pair.Key)
                {
                    try
                    {
                        tab.Add(int.Parse(c.ToString()));
                    }
                    catch
                    {
                        if (c == 'T')
                            tab.Add(10);
                        if (c == 'J')
                            tab.Add(1);
                        if (c == 'Q')
                            tab.Add(12);
                        if (c == 'K')
                            tab.Add(13);
                        if (c == 'A')
                            tab.Add(14);
                    }
                }

                if (count == 0)
                {
                    fourthRankOrdered.Add(new Hand(pair.Key, tab));
                    count++;
                    continue;
                }
                int listCounter = 0;

                foreach (var hand in fourthRankOrdered)
                {
                    if (tab[0] > hand.values[0])
                    {
                        fourthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[0] < hand.values[0])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[1] > hand.values[1])
                    {
                        fourthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[1] < hand.values[1])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[2] > hand.values[2])
                    {
                        fourthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[2] < hand.values[2])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[3] > hand.values[3])
                    {
                        fourthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[3] < hand.values[3])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[4] > hand.values[4])
                    {
                        fourthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[4] < hand.values[4])
                    {
                        listCounter++;
                        continue;
                    }
                }
                if (!added)
                    fourthRankOrdered.Add(new Hand(pair.Key, tab));
            }
            fourthRankOrdered.Reverse();

            var fifthRankOrdered = new List<Hand>();
            count = 0;
            foreach (var pair in fifthRank)
            {
                var tab = new List<int>(5);
                bool added = false;
                foreach (char c in pair.Key)
                {
                    try
                    {
                        tab.Add(int.Parse(c.ToString()));
                    }
                    catch
                    {
                        if (c == 'T')
                            tab.Add(10);
                        if (c == 'J')
                            tab.Add(1);
                        if (c == 'Q')
                            tab.Add(12);
                        if (c == 'K')
                            tab.Add(13);
                        if (c == 'A')
                            tab.Add(14);
                    }
                }

                if (count == 0)
                {
                    fifthRankOrdered.Add(new Hand(pair.Key, tab));
                    count++;
                    continue;
                }
                int listCounter = 0;

                foreach (var hand in fifthRankOrdered)
                {
                    if (tab[0] > hand.values[0])
                    {
                        fifthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[0] < hand.values[0])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[1] > hand.values[1])
                    {
                        fifthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[1] < hand.values[1])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[2] > hand.values[2])
                    {
                        fifthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[2] < hand.values[2])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[3] > hand.values[3])
                    {
                        fifthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[3] < hand.values[3])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[4] > hand.values[4])
                    {
                        fifthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[4] < hand.values[4])
                    {
                        listCounter++;
                        continue;
                    }
                }
                if (!added)
                    fifthRankOrdered.Add(new Hand(pair.Key, tab));
            }
            fifthRankOrdered.Reverse();

            var sixthRankOrdered = new List<Hand>();
            count = 0;
            foreach (var pair in sixthRank)
            {
                var tab = new List<int>(5);
                bool added = false;
                foreach (char c in pair.Key)
                {
                    try
                    {
                        tab.Add(int.Parse(c.ToString()));
                    }
                    catch
                    {
                        if (c == 'T')
                            tab.Add(10);
                        if (c == 'J')
                            tab.Add(1);
                        if (c == 'Q')
                            tab.Add(12);
                        if (c == 'K')
                            tab.Add(13);
                        if (c == 'A')
                            tab.Add(14);
                    }
                }

                if (count == 0)
                {
                    sixthRankOrdered.Add(new Hand(pair.Key, tab));
                    count++;
                    continue;
                }
                int listCounter = 0;

                foreach (var hand in sixthRankOrdered)
                {
                    if (tab[0] > hand.values[0])
                    {
                        sixthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[0] < hand.values[0])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[1] > hand.values[1])
                    {
                        sixthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[1] < hand.values[1])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[2] > hand.values[2])
                    {
                        sixthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[2] < hand.values[2])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[3] > hand.values[3])
                    {
                        sixthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[3] < hand.values[3])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[4] > hand.values[4])
                    {
                        sixthRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[4] < hand.values[4])
                    {
                        listCounter++;
                        continue;
                    }
                }
                if (!added)
                    sixthRankOrdered.Add(new Hand(pair.Key, tab));
            }
            sixthRankOrdered.Reverse();

            var seventhRankOrdered = new List<Hand>();
            count = 0;
            foreach (var pair in seventhRank)
            {
                var tab = new List<int>(5);
                bool added = false;
                foreach (char c in pair.Key)
                {
                    try
                    {
                        tab.Add(int.Parse(c.ToString()));
                    }
                    catch
                    {
                        if (c == 'T')
                            tab.Add(10);
                        if (c == 'J')
                            tab.Add(1);
                        if (c == 'Q')
                            tab.Add(12);
                        if (c == 'K')
                            tab.Add(13);
                        if (c == 'A')
                            tab.Add(14);
                    }
                }

                if (count == 0)
                {
                    seventhRankOrdered.Add(new Hand(pair.Key, tab));
                    count++;
                    continue;
                }
                int listCounter = 0;

                foreach (var hand in seventhRankOrdered)
                {
                    if (tab[0] > hand.values[0])
                    {
                        seventhRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[0] < hand.values[0])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[1] > hand.values[1])
                    {
                        seventhRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[1] < hand.values[1])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[2] > hand.values[2])
                    {
                        seventhRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[2] < hand.values[2])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[3] > hand.values[3])
                    {
                        seventhRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[3] < hand.values[3])
                    {
                        listCounter++;
                        continue;
                    }

                    if (tab[4] > hand.values[4])
                    {
                        seventhRankOrdered.Insert(listCounter, new Hand(pair.Key, tab));
                        listCounter++;
                        added = true;
                        break;
                    }
                    if (tab[4] < hand.values[4])
                    {
                        listCounter++;
                        continue;
                    }
                }
                if (!added)
                    seventhRankOrdered.Add(new Hand(pair.Key, tab));
            }
            seventhRankOrdered.Reverse();
            
            var fullOrdered = new List<Hand>();
            fullOrdered.AddRange(firstRankOrdered);
            fullOrdered.AddRange(secondRankOrdered);
            fullOrdered.AddRange(thirdRankOrdered);
            fullOrdered.AddRange(fourthRankOrdered);
            fullOrdered.AddRange(fifthRankOrdered);
            fullOrdered.AddRange(sixthRankOrdered);
            fullOrdered.AddRange(seventhRankOrdered);

            BigInteger finalSum = 0;
            count = 1;

            Console.WriteLine("All count: "+pairs.Count);
            Console.WriteLine("Ordered count: " + fullOrdered.Count);
            Console.WriteLine("firstRank count: " + firstRank.Count());
            Console.WriteLine("firstRankOrdered count: " + firstRankOrdered.Count);

            Console.WriteLine("second count: " + secondRank.Count());
            Console.WriteLine("second count: " + secondRankOrdered.Count);

            Console.WriteLine("3 count: " + thirdRank.Count());
            Console.WriteLine("3 count: " + thirdRankOrdered.Count);

            Console.WriteLine("4 count: " + fourthRank.Count());
            Console.WriteLine("4 count: " + fourthRankOrdered.Count);

            Console.WriteLine("5 count: " + fifthRank.Count());
            Console.WriteLine("5 count: " + fifthRankOrdered.Count);

            Console.WriteLine("6 count: " + sixthRank.Count());
            Console.WriteLine("6 count: " + sixthRankOrdered.Count);

            Console.WriteLine("7 count: " + seventhRank.Count());
            Console.WriteLine("7 count: " + seventhRankOrdered.Count);

            Console.WriteLine("0 count "+ zero.Count());
            foreach (var z in zero)
                Console.WriteLine("Key: " + z.Key + " Value: " + z.Value);

            count = 1;
            foreach (var hand in fullOrdered)
            {
                //Console.WriteLine(hand.hand + " " + count + " value" + pairs[hand.hand]);
                finalSum += pairs[hand.hand] * count;
                count++;
            }
            Console.WriteLine(finalSum);
        }
    }
}