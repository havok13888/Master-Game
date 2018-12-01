using System;
using System.Drawing;
using MasterGame.Global;
using MasterGame.Entities;
using MasterGame.World;
using System.Threading;

namespace MasterGame.Manager
{
    public class GameManager
    {
        readonly EntityManager MasterEntityManager;
        readonly WorldManager MasterWorldManager;
        readonly InputManager MasterInputManager;
        protected GameState MasterGameState = GameState.Started;

        public GameManager(ref EntityManager entityManager, ref WorldManager worldManager, ref InputManager inputManager)
        {
            MasterEntityManager = entityManager;
            MasterWorldManager = worldManager;
            MasterInputManager = inputManager;
        }

        public void ProcessGame()
        {
            InputCommand command = MasterInputManager.PopCommand();
            PlayerEntity player = MasterEntityManager.GetPlayer() as PlayerEntity;
            if(player == null)
            {
                Console.WriteLine("Player is NULL");
                Environment.Exit(0);
            }

            if (command == InputCommand.Unknown)
            {
                //If there are no commands to process don't do anything
                return;
            }

            if (command == InputCommand.RestartGameSameMap)
            {
                if (MasterWorldManager.GetCurrentMap() == null)
                {
                    MasterWorldManager.Initialize();
                }
                else
                {
                    ResetGame(ref player);
                }

                MasterGameState = GameState.Running;
            }

            if (command == InputCommand.RestartGameDifferentMap)
            {
                MasterWorldManager.Initialize();
                player.Reset();
                MasterGameState = GameState.Running;
            }

            if (command == InputCommand.ExitGame)
            {
                MasterGameState = GameState.Ended;
                Console.Clear();
                Console.WriteLine("Thank you for playing!");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

            if (!player.isAlive())
            {
                MasterGameState = GameState.Ended;
                return;
            }

            if (MasterGameState == GameState.Running)
            {
                Point currentPosition = player.Position;
                MoveEntities(ref player, command);
                UpdateTiles(currentPosition, player.Position);
                UpdateDamage(ref player);
            }
        }

        protected void MoveEntities(ref PlayerEntity player, InputCommand command)
        {
            Point currentPosition = player.Position; 
            Point nextPosition = GetNextPosition(currentPosition, command);
            if(!MasterWorldManager.CanMoveTo(nextPosition))
            {
                return;
            }

            player.Position = nextPosition;
        }

        protected Point GetNextPosition(Point currentPosition, InputCommand command)
        {
            switch (command)
            {
                case InputCommand.MoveUp:
                    return new Point(currentPosition.X, currentPosition.Y - 1);
                case InputCommand.MoveDown:
                    return new Point(currentPosition.X, currentPosition.Y + 1);
                case InputCommand.MoveLeft:
                    return new Point(currentPosition.X - 1, currentPosition.Y);
                case InputCommand.MoveRight:
                    return new Point(currentPosition.X + 1, currentPosition.Y);
                case InputCommand.Stay:
                    return currentPosition;
                default:
                    return new Point(-1, -1);
            }
        }

        protected void UpdateTiles(Point prevPos, Point currPos)
        {
            BaseTile tile = MasterWorldManager.TileAt(prevPos);
            if (tile != null)
            {
                tile.Occupied = false;
            }

            tile = MasterWorldManager.TileAt(currPos);
            if(tile != null)
            {
                tile.Occupied = true;
            }
        }

        protected void UpdateDamage(ref PlayerEntity player)
        {
            BaseTile tile = MasterWorldManager.TileAt(player.Position);
            if (tile != null)
            {
                player.UpdateProperties(tile.Damage);
            }
        }

        protected void ResetGame(ref PlayerEntity player)
        {
            player.Reset();
            //Reset tiles
            MasterWorldManager.ResetTileWhenGameRestarts();
        }
    }
}
