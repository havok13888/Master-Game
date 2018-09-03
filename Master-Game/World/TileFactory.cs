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
                    return new GrassTile(1, 1);
                case TileType.Lava:
                    return new LavaTile(1, 1);
                case TileType.Water:
                    return new WaterTile(1, 1);
                default:
                    return null;
            }
        }
    }
}
