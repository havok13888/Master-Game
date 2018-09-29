namespace MasterGame.World
{
    public class BaseTile
    {
        public TileType Type { get; }
        public bool Passable { get; }
        public bool Occupied { get; set; }
        public int Elevation { get; }
        public float Damage { get; }

        public BaseTile(TileType type, bool passable, float damage)
        {
            Type = type;
            Passable = passable;
            Occupied = false;
            Elevation = 0;
            Damage = damage;
        }
    }
}
