using System.Numerics;

namespace _11._12._2023
{
    class Tile
    {
        public int x; public int y;
        public bool galaxy;
        public bool expanding;
        public Tile(int x, int y, bool galaxy)
        {
            this.x = x;
            this.y = y;
            this.galaxy = galaxy;
            this.expanding = false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<char>> tiles = new List<List<char>>();
            List<string> expanding = new List<string>();
            string input;
            int y = 0;
            while ((input = Console.ReadLine()) != "")
            {
                tiles.Add(new List<char>());
                int x = 0;
                foreach (var c in input)
                {
                    tiles[y].Add(c);
                    x++;
                }
                y++;
            }

            for(int i = 0; i < tiles.Count;i++) 
            {
                var l = tiles[i];
                if (!l.Contains('#'))
                {
                    int x = 0;
                    foreach (var item in l)
                    {
                        expanding.Add(i + "-" + x);
                        x++;
                    }
                }
               
            }

            for (int j = 0; j < tiles[0].Count; j++)
            {
                int x = 0;
                bool check = false;
                for (int i = 0; i < tiles.Count; i++)
                {
                    //Console.WriteLine(i+" "+j);
                    if (tiles[i][j] == '#')
                        check = true;
                }
                if (!check)
                {
                    for (int i = 0; i < tiles.Count; i++)
                    {
                        expanding.Add(i + "-" + j);
                    }
                }
            }

            List<List<Tile>> map = new List<List<Tile>>();
            List<Tile> galaxies = new List<Tile>();
            y = 0;
            foreach (var l in tiles)
            {
                int x = 0;
                map.Add(new List<Tile>());
                foreach (var t in l)
                {
                    bool galaxy = t == '#';
                    map[y].Add(new Tile(x, y, galaxy));
                    if(galaxy)
                    {
                        galaxies.Add(new Tile(x, y, galaxy));
                    }
                    x++;
                }
                y++;
            }
            
            foreach(var e in expanding)
            {
                var split = e.Split('-');
                map[int.Parse(split[0])][int.Parse(split[1])].expanding = true;
            }
            
            BigInteger sum = 0;
            for (int i = galaxies.Count-1; i >= 0  ; i--)
            {
                var galaxy = galaxies[i];
                for (int j = 0; j < i; j++)
                {
                    int gX,gY,sX,sY;
                    var secondGalaxy = galaxies[j];
                    gX = galaxy.x; gY = galaxy.y;
                    sX = secondGalaxy.x; sY = secondGalaxy.y;
                    BigInteger finalY = 0;
                    for(int k = gY-1;k >= sY; k--)
                    {
                        finalY++;
                        if (map[k][gX].expanding)
                        {
                            finalY += 999999;
                        }
                    }
                    BigInteger finalX = 0;
                    if (gX > sX)
                    {
                        for (int k = gX-1; k >= sX; k--)
                        {
                            if (map[gY][k].expanding)
                            {
                                finalX += 999999;
                            }
                            finalX++;
                        }
                    }
                    else
                    {
                        for (int k = gX+1; k <= sX; k++)
                        {
                            if (map[gY][k].expanding)
                                finalX += 999999;
                            finalX++;
                        }
                    }
                    sum += finalY + finalX;
                }
            }
            Console.WriteLine(sum);
        }
    }
}