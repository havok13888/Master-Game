using System;
using System.Timers;
using MasterGame.Manager;
using MasterGame.World;

namespace MasterGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            OpenTK.GameWindow window = new OpenTK.GameWindow(1000, 1000);
            MainGame game = new MainGame(window);

            window.Run(1.0 / 60.0);
            /*
            SystemManager globalGameManager = new SystemManager();

            Console.WriteLine("Welcome to the game!\n");
            Console.WriteLine("Use W,S,A,D to move around and do what you need to win.");
            Console.WriteLine("Good luck explorer! Press Y to start.");

            while (true) //Game Loop
            {
                globalGameManager.ProcessInput();
                globalGameManager.ProcessGame();
                globalGameManager.ProcessGraphics();
            }
            */
        }
    }
}
