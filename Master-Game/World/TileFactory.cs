using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGame.World
{
    public class TileFactory
    {
        public static BaseTile CreateTile(TileType tileType)
        {
            switch (tileType)
            {
                case TileType.Grass:
                    return new GrassTile();
                case TileType.Lava:
                    return new LavaTile();
                case TileType.Water:
                    return new WaterTile();
                default:
                    return null;
            }
        }
    }
}
