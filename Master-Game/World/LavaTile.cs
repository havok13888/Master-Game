using System;
namespace MasterGame.Tiles
{
    public class LavaTile : BaseTile
    {
        public LavaTile(int length, int height)
            : base (TileType.Lava, true, length, height)
        {
        }
    }
}
