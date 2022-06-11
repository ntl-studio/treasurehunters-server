namespace NtlStudio.TreasureHunters.Game;

public class GameRepository
{
    public GameState GetById(Guid gameId)
    {
        var game = new GameState(gameId);
        return game;
    }
}