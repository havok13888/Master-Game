using System;
using System.Collections.Generic;
using MasterGame.Global;

namespace MasterGame.Manager
{
    public class InputManager
    {
        List<InputCommand> InputCommandList = new List<InputCommand>();

        public InputManager()
        {
        }

        public void ProcessInput()
        {
            string userInputString = Console.ReadKey().KeyChar.ToString().ToLower();
            if(userInputString.Length == 1)
            {
                InputCommandList.Add(GetCommandFromInputString(userInputString));
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
                return InputCommand.RestartGame;
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
