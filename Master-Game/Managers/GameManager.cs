using System;
using System.Drawing;
using MasterGame.Global;
using MasterGame.Entities;

namespace MasterGame.Manager
{
    public class GameManager
    {
        EntityManager MasterEntityManager;
        WorldManager MasterWorldManager;
        InputManager MasterInputManager;
        GameState MasterGameState = GameState.Started;

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

            if (command == InputCommand.Unknown)
            {
                //If there are no commands to process don't do anything
                return;
            }

            MoveEntities(ref player, command);
        }

        protected void MoveEntities(ref PlayerEntity player, InputCommand command)
        {
            Point currentPosition = player.Position; 
            Point nextPosition = GetNextPosition(currentPosition, command);
            if(!MasterWorldManager.CanMoveTo(nextPosition))
            {
                Console.WriteLine("Cannot Move there!");
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
    }
}
