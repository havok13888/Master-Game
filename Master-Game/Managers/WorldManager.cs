using System.Drawing;
using MasterGame.World;

namespace MasterGame.Manager
{
    public class WorldManager
    {
        private Map CurrentMap;

        public void Initialize()
        {
            CurrentMap = new Map();
            CurrentMap.LoadMap();
        }

        public BaseTile TileAt(Point position)
        {
            return CurrentMap.TileAt(position);
        }

        public bool CanMoveTo(Point position)
        {
            BaseTile nextTile = TileAt(position);
            if(nextTile == null)
            {
                return false;
            }

            if(nextTile.Passable && !nextTile.Occupied)
            {
                return true;
            }

            return false;
        }

        public void ResetTileWhenGameRestarts()
        {
            //Call a method in the current Map Class that resets the tiles
            CurrentMap.ResetTiles();
        }

        public Map GetCurrentMap()
        {
            return CurrentMap;
        }
    }
}
