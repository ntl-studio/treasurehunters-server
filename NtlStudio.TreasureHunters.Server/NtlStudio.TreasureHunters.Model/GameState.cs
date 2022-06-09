namespace NtlStudio.TreasureHunters.Game;

public class GameState
{
    public GameState(Guid gameId)
    {
        GameId = gameId;
    }

    public Guid GameId { get; }
}