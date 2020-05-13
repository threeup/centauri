using System;
using System.Collections.Generic;

namespace centauri
{
    public class Tile
    {
        public Char TileChar { get; set; }
        public List<TileLayer> Layers;

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
