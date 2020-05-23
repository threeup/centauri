using System;
using System.Collections.Generic;

namespace centauri
{
    
    public enum TileType
    {
        Ice,
        Forest,
        Desert,
        Grass,
        Ocean,
        Lava,
        Ash,
        Cloud,
    };

    public enum LayerType
    {
        Heat,
        Voronoi,
    }


    public class Tile
    {
        public Vec2 Location { get; set; }
        public int X { get => Location.x; }
        public int Y { get => Location.y; }
        public TileType TileType { get; set; }
        public Dictionary<LayerType, TileLayer> Layers;

        public int Height { get; set; }

        public string Summary { get; set; }
    }
    
    public class TileLayer
    {
        public LayerType LayerType { get; set; }
    }

    public class HeatLayer : TileLayer
    {
        public int Heat { get; set; }
    }

    public class VoronoiLayer : TileLayer
    {
        public Vec2 VoronoiSite { get; set; }
        public Vec3 VoronoiColor { get; set; }
    }


    [Serializable]
    public class VerboseMap
    {
        public int width;
        public int height;
        public string[] tileChar;
        public int[] temperatureC;
    }

    public class Map
    {
        public Vec2 Dimensions { get; set; }
        public int Width { get => Dimensions.x; }
        public int Height { get => Dimensions.y; }
        public Tile[] tiles;

        public int Idx(int x, int y) { return y * Dimensions.x + x; }

        public Map(int inWidth, int inHeight)
        {
            Dimensions = new Vec2(inWidth, inHeight);
        }
        
    }
}
