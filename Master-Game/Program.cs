﻿using System;
using System.Timers;
using MasterGame.Manager;

namespace MasterGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
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
        }
    }
}
