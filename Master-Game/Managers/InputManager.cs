using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using MasterGame.Global;

namespace MasterGame.Manager
{
    public class InputManager
    {
        bool startGame = true;
        List<InputCommand> InputCommandList = new List<InputCommand>();
        
        public InputManager()
        {
        }

        public void ProcessInput()
        {
            if (startGame)
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                        {
                            startGame = false;
                            InputCommandList.Add(InputCommand.RestartGameDifferentMap);
                            break;
                        }
                        else if (Console.ReadKey(true).Key == ConsoleKey.X)
                        {
                            startGame = false;
                            InputCommandList.Add(InputCommand.ExitGame);
                            break;
                        }
                    }
                }
            }
            else
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                string userInputString = "p";
                while (stopwatch.Elapsed.Seconds < 1)
                {
                    if (Console.KeyAvailable)
                    {
                        userInputString = Console.ReadKey(true).KeyChar.ToString().ToLower();
                        break;
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }

                stopwatch.Stop();
                
                if (userInputString.Length == 1)
                {
                    InputCommandList.Add(GetCommandFromInputString(userInputString));
                }
            }
        }

        protected InputCommand GetCommandFromInputString(string userInputString)
        {
            if (userInputString.Equals("w"))
            {
                return InputCommand.MoveUp;
            }
            else if (userInputString.Equals("s"))
            {
                return InputCommand.MoveDown;
            }
            else if (userInputString.Equals("a"))
            {
                return InputCommand.MoveLeft;
            }
            else if (userInputString.Equals("d"))
            {
                return InputCommand.MoveRight;
            }
            else if (userInputString.Equals("x"))
            {
                return InputCommand.ExitGame;
            }
            else if (userInputString.Equals("y"))
            {
                return InputCommand.RestartGameDifferentMap;
            }
            else if (userInputString.Equals("p"))
            {
                return InputCommand.Stay;
            }
            else if (userInputString.Equals("z"))
            {
                return InputCommand.RestartGameSameMap;
            }

            return InputCommand.Unknown;
        }

        public InputCommand PopCommand()
        {
            InputCommand command = InputCommand.Unknown; 
            if (InputCommandList.Count > 0)
            {
                command = InputCommandList[0];
                InputCommandList.RemoveAt(0);
            }
            return command;
        }
    }
}
