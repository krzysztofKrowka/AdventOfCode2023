namespace _10._12._2023
{
    public class Tile
    {
        public char c;
        public bool part, inside;
        public bool left,top;
        public Tile(char c)
        {
            this.c = c;
            part = false;
            top = false;
            left = false;
            inside = false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<Tile>> map = new List<List<Tile>>();
            Dictionary<char, char> replaces = new Dictionary<char, char> { { '|', '║' }, { '-', '═' }, { 'L', '╚' }, { 'J', '╝' }, { '7', '╗' }, { 'F', '╔' }, { 'S', '╝' } };
            string input;
            int counter = 0,x=0,y=0;
            while ((input = Console.ReadLine()) != "")
            {
                map.Add(new List<Tile>());
                int xCounter = 0;
                foreach (var c in input)
                {
                    map[counter].Add(new Tile(c));
                    if(c == 'S')
                    {
                        x = xCounter;
                        y = counter;

                    }
                    xCounter++;
                }
                counter++;
            }
            char pom = map[y][x - 1].c;
            Console.WriteLine(pom);
            y = y;
            x = x-1;
            map[y][x].part = true;

            int stepCounter = 0;
            bool where = false, top = false, bottom = false, left = true, right = false;
            while(pom != 'S')
            {

                if (pom == '-' && left)
                {
                    map[y][x].left = true;
                    pom = map[y][x - 1].c;
                    y = y;
                    x = x - 1;

                }
                else if (pom == '-' && right)
                {
                    map[y][x].left = false;
                    pom = map[y][x + 1].c;
                    y = y;
                    x = x + 1;

                }

                else if (pom == '|' && top)
                {
                    map[y][x].top = true;
                    pom = map[y - 1][x].c;
                    y = y - 1;
                    x = x;
                    
                }
                else if (pom == '|' && bottom)
                {
                    map[y][x].top = true;
                    pom = map[y + 1][x].c;
                    y = y + 1;
                    x = x;
                }

                else if (pom == 'F' && !where)
                {
                    map[y][x].left = true;
                    pom = map[y + 1][x].c;
                    y = y + 1;
                    x = x;
                    where = true;
                    //stepCounter++;
                    top = false;
                    bottom = true;
                    left = false;
                    right = false;

                }
                else if (pom == 'F' && where)
                {
                    map[y][x].left = false;
                    pom = map[y][x + 1].c;
                    y = y;
                    x = x + 1;
                    where = false;
                    //stepCounter++;
                    top = false;
                    bottom = false;
                    left = false;
                    right = true;

                }

                else if (pom == 'L' && !where)
                {
                    map[y][x].left = true;
                    pom = map[y - 1][x].c;
                    y = y-1;
                    x = x;
                    where = true;
                    //stepCounter++;
                    top = true;
                    bottom = false;
                    left = false;
                    right = false;
                    
                }
                else if (pom == 'L' && where)
                {
                    map[y][x].left = false ;
                    pom = map[y][x + 1].c;
                    y = y;
                    x = x+1;
                    where = false;
                    //stepCounter++;
                    top = false;
                    bottom = false;
                    left = false;
                    right = true;
                    
                }

                else if (pom == '7' && !where)
                {
                    map[y][x].left = false;
                    pom = map[y + 1][x].c;
                    y = y + 1;
                    x = x;
                    where = true;
                    //stepCounter++;
                    top = false;
                    bottom = true;
                    left = false;
                    right = false;
                    
                }
                else if (pom == '7' && where)
                {
                    map[y][x].left = true;
                    pom = map[y][x - 1].c;
                    y = y;
                    x = x - 1;
                    where = false;
                    //stepCounter++;
                    top = false;
                    bottom = false;
                    left = true;
                    right = false;
                    
                }

                else if (pom == 'J' && !where)
                {
                    map[y][x].left = false;
                    pom = map[y - 1][x].c;
                    y = y - 1;
                    x = x;
                    where = true;
                    //stepCounter++;
                    top = true;
                    bottom = false;
                    left = false;
                    right = false;
                    
                }
                else if (pom == 'J' && where)
                {
                    map[y][x].left = true;
                    pom = map[y][x - 1].c;
                    y = y;
                    x = x - 1;
                    where = false;

                    //stepCounter++;
                    top = false;
                    bottom = false;
                    left = true;
                    right = false;
                    
                }
                map[y][x].part = true;
                stepCounter++;
                //Console.WriteLine(pom);
            }

            Console.WriteLine("sdad "+stepCounter);
            
            if((stepCounter%2) == 0){
                Console.WriteLine(stepCounter/2);
            }
            else
            {
                int p = stepCounter + 1;
                Console.WriteLine("p: " + p);
                Console.WriteLine(p/2);
            }
            int inside = 0;
           
            for (int i = 1; i < map.Count; i++)
            {
                var line = map[i];
                int xC = 0;
                
                foreach (var c in line) 
                {
                    int nR = 0;
                    if (c.part)
                    {
                        //Console.WriteLine("skipped: "+c.c);
                        xC++;
                        continue;
                    }

                    List<char> L = new List<char>(),R = new List<char>();
                    for(int j = i-1; j >= 0; j--)
                    {
                        if (map[j][xC].part && !map[j][xC].top)
                        {
                            
                            if (map[j][xC].left)
                            {
                                L.Add(map[j][xC].c);
                                nR++;
                                //Console.Write("L");
                            }
                            else 
                            {
                                R.Add(map[j][xC].c);
                                //Console.Write('R');
                                nR--;
                            }
                                
                            //Console.Write(" "+map[j][xC].c+"   ");
                        }
                    }
                    bool isBottom = true;
                    for (int j = i+1;j < map.Count; j++)
                    {
                        if (map[j][xC].part)
                            isBottom = false;
                    }
                    bool deleting = true;
                    while (deleting) 
                    {
                        if (L.Contains('J') && L.Contains('F'))
                        {
                            nR--;
                            L.Remove('J');
                            L.Remove('F');
                        }
                        else
                            deleting = false;
                    }
                    deleting = true;
                    while (deleting)
                    {
                        if (L.Contains('L') && L.Contains('7'))
                        {
                            nR--;
                            L.Remove('L');
                            L.Remove('7');
                        }
                        else
                            deleting = false;
                    }
                    
                    deleting = true;
                    while (deleting)
                    {
                        if (R.Contains('J') && R.Contains('F'))
                        {
                            nR++;
                            R.Remove('J');
                            R.Remove('F');
                        }
                        else
                            deleting = false;
                    }
                    deleting = true;
                    while (deleting)
                    {
                        if (R.Contains('L') && R.Contains('7'))
                        {
                            nR++;
                            R.Remove('L');
                            R.Remove('7');
                        }
                        else
                            deleting = false;
                    }
                    xC++;
                    //Console.WriteLine("   "+nR);
                    if (nR != 0 && !isBottom)
                    {
                        inside++;
                        c.inside = true;
                    }
                }
                //Console.WriteLine();
            }
            Console.WriteLine("Inside: "+inside);
            foreach (var m in map)
                {
                    foreach (var l in m)
                    {
                        if (l.inside)
                            Console.Write("I");
                        else if (l.part)
                        Console.Write(replaces[l.c]);
                        else
                            Console.Write(".");
                    }
                    Console.Write('\n');
                }

        }
    }
}