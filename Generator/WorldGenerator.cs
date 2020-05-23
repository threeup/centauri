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

        public static void Generate(int seed, ref Map map)
        {
            var generateSeed = seed > 0 ? seed : 1234;
            var rng = new Random(generateSeed);
            map.tiles = new Tile[map.Width * map.Height];
            
            for(var itY=0; itY<map.Height; ++itY)
            {
                for (var itX=0; itX<map.Width; ++itX)
                {
                    var idx = GetTileIndex(itX,itY,map.Width);
                    var c = TileChars[rng.Next(TileChars.Length)];
                    map.tiles[idx] = new Tile{
                        Location = new Vec2(itX, itY),
                        Layers = new Dictionary<LayerType, TileLayer>(),
                        TileType = WorldLib.ConvertCharToTileType(c),
                        Height = rng.Next(-20, 55),
                    };
                    var heatLayer = new HeatLayer{Heat = rng.Next(-20, 55)};
                    map.tiles[idx].Layers.Add(LayerType.Heat, heatLayer);
                }
            }
            VoronoiLib.Voronoi(generateSeed, map.Dimensions, ref map);
        }
    }

}
