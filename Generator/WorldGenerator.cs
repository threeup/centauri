using System;
using System.Collections.Generic;
namespace centauri.generator
{
    public class WorldGenerator
    {

        private static readonly Char[] TileChars = new[]
        {
            'I', 'O', 'G', 'F','L','D','A',
        };

        static int GetTileIndex(int x, int y, int w)
        {
            return y*w+x;
        }

        public static void Generate(int seed, ref Map ceData)
        {
            
            var rng = seed > 0 ? new Random(seed) : new Random();
            ceData.tiles = new Tile[ceData.width*ceData.height];
            
            for(int j=0; j<ceData.height; ++j)
            {
                for (int i=0; i<ceData.width; ++i)
                {
                    int idx = GetTileIndex(i,j,ceData.width);
                    char c = TileChars[rng.Next(TileChars.Length)];
                    ceData.tiles[idx] = new Tile{
                        Layers = new List< TileLayer>(),
                        TileType = WorldLib.ConvertCharToTileType(c),
                        TemperatureC = rng.Next(-20, 55),
                    };
                    ceData.tiles[idx].Layers.Add(new  TileLayer{Heat = rng.Next(5)});
                }
            }
        }
    }

}
