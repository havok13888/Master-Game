using System;
using System.Drawing;
using MasterGame.Global;
using MasterGame.Entities;
using MasterGame.World;

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

            if (command == InputCommand.RestartGame)
            {
                Console.WriteLine("Lets go!");
                ResetGame(ref player);
            }

            if (command == InputCommand.ExitGame)
            {
                Console.WriteLine("Thank you for playing");
                Environment.Exit(0);
            }

            if (!player.isAlive())
            {
                MasterGameState = GameState.Ended;
                return;
            }

            Point currentPosition = player.Position;
            MoveEntities(ref player, command);
            UpdateTiles(currentPosition, player.Position);
            UpdateDamage(ref player);
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
                player.HealthPoints -= tile.Damage;
            }
        }

        protected void ResetGame(ref PlayerEntity player)
        {
            MasterGameState = GameState.Started;
            player.Reset();
            //Reset tiles
            MasterWorldManager.ResetTileWhenGameRestarts();
        }
    }
}
