using System;
using System.Collections.Generic;
namespace centauri.generator
{
    public class WorldGenerator
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly Char[] TileChars = new[]
        {
            'F', 'B', 'C', 'X',
        };

        static int GetTileIndex(int x, int y)
        {
            return y*8+x;
        }

        public static void Generate(int w, int h, out Tile[] tiles)
        {
            
            var rng = new Random();
            tiles = new Tile[w*h];
            for (int i=0; i<w; ++i)
            {
                for(int j=0; j<h; ++j)
                {
                    int idx = GetTileIndex(i,j);
                    tiles[idx] = new Tile{
                        Layers = new List<TileLayer>(),
                        TileChar = TileChars[rng.Next(TileChars.Length)],
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)],
                    };
                    tiles[idx].Layers.Add(new TileLayer{Heat = rng.Next(5)});
                }
            }
        }
    }

}
