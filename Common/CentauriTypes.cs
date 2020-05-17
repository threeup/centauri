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


    public class Tile
    {
        public TileType TileType { get; set; }
        public List< TileLayer> Layers;

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
    
    public class TileLayer
    {
        public int Heat { get; set; }
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
        public int width;
        public int height;
        public Tile[] tiles;

        public Map(int inWidth, int inHeight)
        {
            width = inWidth;
            height = inHeight;
        }
        
    }
}
