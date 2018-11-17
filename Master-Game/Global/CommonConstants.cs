namespace MasterGame.Global
{
    public enum InputCommand
    {
        Unknown,
        Stay,
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        ExitGame,
        RestartGameDifferentMap,
        RestartGameSameMap
    }

    public enum GameState
    {
        Started,
        Running,
        Ended
    }
}
