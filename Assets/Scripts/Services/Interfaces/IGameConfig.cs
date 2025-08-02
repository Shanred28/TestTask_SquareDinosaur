namespace Services.Interfaces
{
    public interface IGameConfig
    {
        int   ClientTimeoutMs        { get; }
        string ConnectionSceneName   { get; }
        string GameSceneName         { get; }
        float MoveSpeed              { get; }
        float MouseSensitivity       { get; }
    }
}
