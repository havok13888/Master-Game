using System;
using System.Drawing;
using MasterGame.World;
using MasterGame.Entities;

namespace MasterGame.Manager
{
    public class RenderingManager
    {
        EntityManager MasterEntityManager;
        WorldManager MasterWorldManager;

        public RenderingManager(ref EntityManager entityManager, ref WorldManager worldManager)
        {
            MasterEntityManager = entityManager;
            MasterWorldManager = worldManager;
        }

        public void ProcessGraphics()
        {
            ClearFrame();
            RenderMap();
        }

        protected void ClearFrame()
        {
            Console.Clear();
        }

        protected void RenderMap()
        {
            //Todo: need a better way to do this later
            Point currentPosition = new Point(0, 0);
            Point playerPosition = new Point(-1, -1);
            PlayerEntity player = MasterEntityManager.GetPlayer() as PlayerEntity;
            if(player != null)
            {
                playerPosition.X = player.Position.X;
                playerPosition.Y = player.Position.Y;
            }
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    currentPosition.X = x;
                    currentPosition.Y = y;
                    if(currentPosition == playerPosition)
                    {
                        Console.Write(" X ");
                        continue;
                    }
                    BaseTile tile = MasterWorldManager.TileAt(currentPosition);
                    if(tile != null)
                    {
                        if(tile.Type == TileType.Grass)
                        {
                            Console.Write(" ^ ");
                        }
                        else if (tile.Type == TileType.Lava)
                        {
                            Console.Write(" ~ ");
                        }
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }
}
