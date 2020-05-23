using System;
using System.Collections.Generic;
namespace centauri.generator
{
    public class VoronoiLib
    {

        public static List<Vec2> MakeVoronoiSites(int seed, Vec2 dimensions, int count)
        {
            var result = new List<Vec2>();
            var seedOffset = 2939;
            
            var rng = seed > 0 ? new Random(seed+seedOffset) : new Random();
            for(var i = 0; i<count; ++i)
            {
                Vec2 next = new Vec2(rng.Next(dimensions.x), rng.Next(dimensions.y));
                result.Add(next);
            }
            return result;
        }

        public static Vec3 GenerateColor(int num)
        {
            int r=128,g=128,b=128;
            int amount = 48;
            //first 15 bits
            for(int i=0; i<5; ++i)
            {
                if((num & 0x1) > 0)
                {
                    r += amount;
                }
                else
                {
                    r -= amount;
                }
                if((num & 0x2) > 0)
                {
                    g += amount;
                }
                else
                {
                    g -= amount;
                }
                if((num & 0x4) > 0)
                {
                    b += amount;
                }
                else
                {
                    b -= amount;
                }
                num >>= 3;
                if (num == 0)
                {
                    break;
                }
                amount /= 2;
            }
            return new Vec3(r,g,b);
        }

        public static void Voronoi(int seed, Vec2 dimensions, ref Map map)
        {
            List<Vec2> sites = MakeVoronoiSites(seed, dimensions, 6);
            for(var itY = 0; itY < dimensions.y; ++itY)
            {
                for(var itX = 0; itX < dimensions.x; ++itX)
                {
                    var idx = map.Idx(itX, itY);
                    map.tiles[idx].Layers.Remove(LayerType.Voronoi);
                    float bestDistance = 9999999;
                    for(var itSite = 0; itSite < sites.Count; ++itSite)
                    {
                        Vec2 site = sites[itSite];
                        float siteDistance = site.DistanceTo(map.tiles[idx].Location);
                        if(itSite == 0)
                        {
                            var layer = new VoronoiLayer{VoronoiSite = site, VoronoiColor = GenerateColor(0)};
                            map.tiles[idx].Layers.Add(LayerType.Voronoi, layer);
                            bestDistance = siteDistance;
                        }
                        else if (siteDistance < bestDistance)
                        {
                            var layer = map.tiles[idx].Layers[LayerType.Voronoi] as VoronoiLayer;
                            layer.VoronoiSite = site;
                            layer.VoronoiColor = GenerateColor(itSite);
                            bestDistance = siteDistance;
                            //map.tiles[idx].Layers[LayerType.Voronoi] = layer;
                        }
                    }
                }
            }
        }
    }
}