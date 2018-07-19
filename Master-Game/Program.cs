using System;
using MasterGame.Manager;

namespace MasterGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press Y to start");

            SystemManager globalGameManager = new SystemManager();

            while(true) //Game Loop
            {
                globalGameManager.ProcessInput();
                globalGameManager.ProcessGame();
                globalGameManager.ProcessGraphics();
            }
        }
    }
}
