using System;

namespace MasterGame.World
{
    public class BaseTile
    {
        public TileType Type { get; internal set; }
        public bool Passable { get; internal set; }
        public bool Occupied { get; set; }
        public int Length { get; internal set; }
        public int Height { get; internal set; }

        public BaseTile(TileType type, bool passable, int length, int height)
        {
            Type = type;
            Passable = passable;
            Occupied = false;
            Length = length;
            Height = height;
        }
    }
}
