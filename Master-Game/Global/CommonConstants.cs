using System;
namespace MasterGame.Global
{
    public enum InputCommand
    {
        Unknown,
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        ExitGame
    }

    public enum GameState
    {
        Started,
        Running,
        Ended
    }
}
