using System;
using System.Collections.Generic;

namespace centauri
{
    public class CentauriTile
    {
        public Char TileChar { get; set; }
        public List< CentauriLayer> Layers;

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
    
    public class CentauriLayer
    {
        public int Heat { get; set; }
    }

    public class CentauriData
    {
        public int width;
        public int height;
        public CentauriTile[] tiles;

        public CentauriData(int inWidth, int inHeight)
        {
            width = inWidth;
            height = inHeight;
        }
        
    }
}
