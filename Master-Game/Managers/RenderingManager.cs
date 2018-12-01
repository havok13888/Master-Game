using System;
using System.Drawing;
using MasterGame.World;
using MasterGame.Entities;

namespace MasterGame.Manager
{
    public class RenderingManager
    {
        readonly EntityManager MasterEntityManager;
        readonly WorldManager MasterWorldManager;

        public RenderingManager(ref EntityManager entityManager, ref WorldManager worldManager)
        {
            MasterEntityManager = entityManager;
            MasterWorldManager = worldManager;
        }

        public void ProcessGraphics()
        {
            ClearFrame();
            PlayerEntity player = MasterEntityManager.GetPlayer() as PlayerEntity;
            if (player != null)
            {
                RenderMap(ref player);
                RenderHud(ref player);
            }
        }

        protected void ClearFrame()
        {
            Console.Clear();
        }

        protected void RenderMap(ref PlayerEntity player)
        {
            //Todo: need a better way to do this later
            Point currentPosition = new Point(0, 0);
            Point playerPosition = new Point(player.Position.X, player.Position.Y);

            int[] currentMapDim = MasterWorldManager.GetCurrentMap().GetMapDim();

            int currentMapRows = currentMapDim[0];
            int currentMapCols = currentMapDim[1];
            for (int y = 0; y < currentMapRows; y++)
            {
                for (int x = 0; x < currentMapCols; x++)
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
                            Console.Write(" G ");
                        }
                        else if (tile.Type == TileType.Lava)
                        {
                            Console.Write(" L ");
                        } 
                        else if(tile.Type == TileType.Water)
                        {
                            Console.Write(" W ");
                        }
                        else if(tile.Type == TileType.Void)
                        {
                            Console.Write(" % ");
                        }
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        protected void RenderHud(ref PlayerEntity player)
        {
            if (player.isAlive())
            {
                Console.WriteLine("HP: " + player.HealthPoints + " / " + player.MaxHealthPoints);
                Console.WriteLine("Where to next?");
            }
            else
            {
                Console.WriteLine("You died!");
                Console.WriteLine("Type X to exit, Y to restart on a map of your choice, Z to restart on same map.");
            }
        }
    }
}
