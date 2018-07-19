namespace MasterGame.World
{
    public class LavaTile : BaseTile
    {
        public LavaTile(int length, int width)
            : base (TileType.Lava, true, length, width, 25.0f)
        {
        }
    }
}
