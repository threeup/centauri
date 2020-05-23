namespace centauri
{
        
    public class WorldLib
    {


        public static TileType ConvertCharToTileType(char c)
        {
            switch(c)
            {
                case 'I': return TileType.Ice;
                case 'F': return TileType.Forest;
                case 'D': return TileType.Desert;
                case 'G': return TileType.Grass;
                case 'O': return TileType.Ocean;
                case 'L': return TileType.Lava;
                case 'A': return TileType.Ash;
                case 'C': return TileType.Cloud;
                default: return TileType.Cloud;
            }
        }

        public static char ConvertTileTypeToChar(TileType tileType)
        {
            switch(tileType)
            {
                case TileType.Ice: return 'I';
                case TileType.Forest: return 'F';
                case TileType.Desert: return 'D';
                case TileType.Grass: return 'G';
                case TileType.Ocean: return 'O';
                case TileType.Lava: return 'L';
                case TileType.Ash: return 'A';
                case TileType.Cloud: return 'C';
                default: return 'C';
            }
        }
    }
}