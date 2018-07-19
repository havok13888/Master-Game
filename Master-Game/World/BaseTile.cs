namespace MasterGame.World
{
    public class BaseTile
    {
        public TileType Type { get; }
        public bool Passable { get; }
        public bool Occupied { get; set; }
        public int Length { get; }
        public int Width { get; }
        public int Elevation { get; }
        public float Damage { get; }

        public BaseTile(TileType type, bool passable, int length, int width, float damage)
        {
            Type = type;
            Passable = passable;
            Occupied = false;
            Length = length;
            Width = width;
            Elevation = 0;
            Damage = damage;
        }
    }
}
