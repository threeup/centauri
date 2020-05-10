using System;

namespace centauri
{
    public class Tile
    {
        public TileLayer Layer { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
