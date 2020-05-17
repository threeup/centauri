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

        static void GetProperty(string label, Func<CentauriTile, string> inFunc, ref CentauriData ceData, ref System.Text.StringBuilder sb)
        {
            int counter = 0;
            int row = 0;
            sb.Append("   \"");
            sb.Append(label);
            sb.Append("\": [");
            foreach(CentauriTile t in ceData.tiles)
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
                if(counter > 0)
                {
                    sb.Append(',', 1);
                }
                sb.Append(inFunc(t));
                counter++;
                if(counter == ceData.width)
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
            int worldWidth = width > 0 ? width : 12;
            int worldHeight = height > 0 ? height : 8;
            int worldSeed = seed > 0 ? seed : 0;
            int total = worldWidth*worldHeight;
            _logger.LogInformation("generating"+total.ToString());
            CentauriData ceData = new CentauriData(worldWidth,worldHeight);
            WorldGenerator.Generate(worldSeed, ref ceData);

            var sb = new System.Text.StringBuilder();
            
            
            sb.Append('{', 1);
            
            sb.AppendLine();
            sb.Append("   \"width\": ");
            sb.Append(ceData.width.ToString());
            sb.AppendLine(",");
            sb.Append("   \"height\": ");
            sb.Append(ceData.height.ToString());
            sb.AppendLine(",");

            Func<CentauriTile, string> tileCharFunc = (t) =>
            {
                return t.TileChar.ToString();
            };
            Func<CentauriTile, string> tileTempFunc = (t) =>
            {
                return t.TemperatureC.ToString();
            };

            GetProperty("tileChar",tileCharFunc, ref ceData, ref sb);
            GetProperty("temperatureC",tileTempFunc, ref ceData, ref sb);
            sb.AppendLine("   \"eof\": \"eof\"");
            sb.Append('}', 1);
            return sb.ToString();
        }
    }
}
