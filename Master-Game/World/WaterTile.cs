using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGame.World
{
    class WaterTile : BaseTile
    {
        public WaterTile(int length, int width)
            :base(TileType.Water, false, length, width, -10.0f)
        {

        }

    }
}
