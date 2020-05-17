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

        static int GetTileIndex(int x, int y, int w)
        {
            return y*w+x;
        }

        public static void Generate(int seed, ref CentauriData ceData)
        {
            
            var rng = seed > 0 ? new Random(seed) : new Random();
            ceData.tiles = new CentauriTile[ceData.width*ceData.height];
            
            for(int j=0; j<ceData.height; ++j)
            {
                for (int i=0; i<ceData.width; ++i)
                {
                    int idx = GetTileIndex(i,j,ceData.width);
                    ceData.tiles[idx] = new CentauriTile{
                        Layers = new List< CentauriLayer>(),
                        TileChar = TileChars[rng.Next(TileChars.Length)],
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)],
                    };
                    ceData.tiles[idx].Layers.Add(new  CentauriLayer{Heat = rng.Next(5)});
                }
            }
        }
    }

}
