using System.Drawing;

namespace MasterGame.World
{
    public class Map
    {
        private BaseTile [,] CurrentMap;

        public void LoadMap()
        {
            CurrentMap = new BaseTile [4,4]
            {
                { new GrassTile(1, 1), new LavaTile(1, 1), new GrassTile(1, 1), new GrassTile(1, 1) },
                { new GrassTile(1, 1), new LavaTile(1, 1), new WaterTile(1, 1), new GrassTile(1, 1) },
                { new GrassTile(1, 1), new GrassTile(1, 1), new WaterTile(1, 1), new GrassTile(1, 1) },
                { new GrassTile(1, 1), new GrassTile(1, 1), new GrassTile(1, 1), new GrassTile(1, 1) }   
            };
        }

        public BaseTile TileAt(Point position)
        {
            //TODO: Need to do this checking in a smarter way
            if(position.X < 0 || position.Y < 0 ||
              position.X >= 4 || position.Y >= 4)
            {
                return null;
            }
            return CurrentMap[position.X, position.Y];
        }
    }
}
