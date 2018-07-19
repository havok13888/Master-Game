namespace MasterGame.Global
{
    public enum InputCommand
    {
        Unknown,
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        ExitGame,
        RestartGame
    }

    public enum GameState
    {
        Started,
        Running,
        Ended
    }
}
