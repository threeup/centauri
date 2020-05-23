using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using centauri.generator;

namespace centauri.Controllers
{
    [ApiController]
    [Route("")]
    public class WorldController : ControllerBase
    {


        private readonly ILogger<WorldController> _logger;

        public WorldController(ILogger<WorldController> logger)
        {
            _logger = logger;
        }

        static void GetProperty(string label, Func<Tile, string> inFunc, 
            bool commas, ref Map ceData, ref System.Text.StringBuilder sb)
        {
            int counter = 0;
            int row = 0;
            sb.Append("   \"");
            sb.Append(label);
            sb.Append("\": [");
            foreach(Tile t in ceData.tiles)
            {
                if(counter == 0)
                {
                    if(row > 0)
                    {
                        sb.Append(',', 1);        
                    }
                    sb.AppendLine();
                    sb.Append("       \"");
                }
                if(commas && counter > 0)
                {
                    sb.Append(',', 1);
                }
                sb.Append(inFunc(t));
                counter++;
                if(counter == ceData.Width)
                {
                    counter=0;
                    row++;
                    sb.Append('"', 1); 
                }
            }
            sb.AppendLine();
            sb.Append("   ],");
            sb.AppendLine();
        }


        [HttpGet]
        public string Get(int width, int height, int seed)
        {
            int worldWidth = width > 0 ? width : 18;
            int worldHeight = height > 0 ? height : 15;
            int worldSeed = seed > 0 ? seed : 0;
            int total = worldWidth*worldHeight;
            _logger.LogInformation("generating"+total.ToString());
            Map ceData = new Map(worldWidth,worldHeight);
            WorldGenerator.Generate(worldSeed, ref ceData);

            var sb = new System.Text.StringBuilder();
            
            
            sb.Append('{', 1);
            
            sb.AppendLine();
            sb.Append("   \"width\": ");
            sb.Append(ceData.Width.ToString());
            sb.AppendLine(",");
            sb.Append("   \"height\": ");
            sb.Append(ceData.Height.ToString());
            sb.AppendLine(",");

            Func<Tile, string> tileCharFunc = (t) =>
            {
                TileType tileType = t.TileType;
                return WorldLib.ConvertTileTypeToChar(tileType).ToString();
            };
            Func<Tile, string> tileHeightFunc = (t) =>
            {
                return t.Height.ToString();
            };
            
            Func<Tile, string> tileColorFunc = (t) =>
            {
                if(t.Layers.ContainsKey(LayerType.Voronoi))
                {
                    VoronoiLayer layer = t.Layers[LayerType.Voronoi] as VoronoiLayer;
                    return layer.VoronoiColor.ToHexString();
                }
                else
                {
                    return "#000000";
                }
            };

            GetProperty("tileChar",tileCharFunc, false, ref ceData, ref sb);
            GetProperty("height",tileHeightFunc, true, ref ceData, ref sb);
            GetProperty("color",tileColorFunc, true, ref ceData, ref sb);
            sb.AppendLine("   \"eof\": \"eof\"");
            sb.Append('}', 1);
            return sb.ToString();
        }
    }
}
