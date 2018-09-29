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
                { new GrassTile(), new LavaTile(), new GrassTile(), new GrassTile() },
                { new GrassTile(), new LavaTile(), new WaterTile(), new GrassTile() },
                { new GrassTile(), new GrassTile(), new WaterTile(), new GrassTile() },
                { new GrassTile(), new GrassTile(), new GrassTile(), new GrassTile() }   
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

        public void ResetTiles()
        {
            //This method should only run if the game restarts
            for(int y = 0; y < 4; y++)
            {
                for(int x = 0; x < 4; x++)
                {
                    CurrentMap[x, y].Occupied = false;
                }
            }
        }
    }
}
