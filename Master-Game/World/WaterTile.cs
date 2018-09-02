using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGame.World
{
    class WaterTile : BaseTile
    {
        public WaterTile()
            :base(TileType.Water, true, -5.0f)
        {

        }

    }
}