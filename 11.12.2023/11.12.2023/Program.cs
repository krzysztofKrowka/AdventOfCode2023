using System.Numerics;

namespace _11._12._2023
{
    class Tile
    {
        public int x; public int y;
        public bool galaxy;
        public Tile(int x, int y, bool galaxy)
        {
            this.x = x;
            this.y = y;
            this.galaxy = galaxy;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<char>> tiles = new List<List<char>>();
            string input;
            int y = 0;
            while ((input = Console.ReadLine()) != "")
            {
                tiles.Add(new List<char>());
                int x = 0;
                foreach (var c in input)
                {
                    bool galaxy = c == '#';
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
                    tiles.Insert(i, new List<char>());
                    i++;
                }
               
            }
            y = 0;
            foreach (var l in tiles)
            {
                if (l.Count == 0)
                {
                    foreach (var t in tiles[0])
                    {
                        l.Add('.');
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
                       tiles[i].Insert(j,'.');
                    }
                    j++;
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
            BigInteger sum = 0;
            for (int i = galaxies.Count-1; i >= 0  ; i--)
            {
                var galaxy = galaxies[i];
                for (int j = 0; j < i; j++)
                {
                    var secondGalaxy = galaxies[j];
                    sum += Math.Abs(galaxy.y - secondGalaxy.y) + Math.Abs(galaxy.x - secondGalaxy.x);
                }
            }
            Console.WriteLine(sum);
        }
    }
}