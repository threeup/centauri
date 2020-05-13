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


        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("generating 64");
            Tile[] tiles;
            WorldGenerator.Generate(8,8, out tiles);

            var sb = new System.Text.StringBuilder();
            int counter = 0;
            foreach(Tile t in tiles)
            {
                sb.Append(t.TileChar, 1);
                if(++counter == 8)
                {
                    counter=0;
                    sb.AppendLine();
                }
            }

            return new string[]{sb.ToString()};
        }
    }
}
