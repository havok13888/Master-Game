namespace MasterGame.World
{
    public class LavaTile : BaseTile
    {
        public LavaTile(int length, int height)
            : base (TileType.Lava, true, length, height, 25.0f)
        {
        }
    }
}
