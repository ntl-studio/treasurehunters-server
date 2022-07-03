using NtlStudio.TreasureHunters.Core;

namespace NtlStudio.TreasureHunters.Game;

public class GameState: Entity<Guid>
{
    private readonly GameField _gameField;
    public GameState(Guid gameId)
    {
        Id = gameId;
        var builder = new GameFieldBuilder(GameField.FieldWidth, GameField.FieldHeight);
        _gameField = GenerateDefaultGameField(builder);
    }

    private GameField GenerateDefaultGameField(GameFieldBuilder builder)
    {
        builder[0, 0] = FieldCell.LeftWall | FieldCell.TopWall;
        builder[1, 0] = FieldCell.TopWall | FieldCell.RightWall | FieldCell.BottomWall;
        builder[2, 0] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[3, 0] = FieldCell.LeftWall | FieldCell.TopWall;
        builder[4, 0] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[5, 0] = FieldCell.TopWall;
        builder[6, 0] = FieldCell.TopWall;
        builder[7, 0] = FieldCell.TopWall;
        builder[8, 0] = FieldCell.TopWall;
        builder[9, 0] = FieldCell.TopWall | FieldCell.RightWall;

        builder[0, 1] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[1, 1] = FieldCell.LeftWall | FieldCell.TopWall;
        builder[2, 1] = FieldCell.RightWall | FieldCell.BottomWall;
        builder[3, 1] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[4, 1] = FieldCell.LeftWall | FieldCell.TopWall | FieldCell.RightWall;
        builder[5, 1] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[6, 1] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[7, 1] = FieldCell.LeftWall | FieldCell.BottomWall | FieldCell.RightWall;
        builder[8, 1] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[9, 1] = FieldCell.LeftWall | FieldCell.RightWall;

        builder[0, 2] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[1, 2] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[2, 2] = FieldCell.TopWall | FieldCell.LeftWall | FieldCell.BottomWall;
        builder[3, 2] = FieldCell.BottomWall;
        builder[4, 2] = FieldCell.BottomWall | FieldCell.RightWall;
        builder[5, 2] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[6, 2] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[7, 2] = FieldCell.LeftWall | FieldCell.TopWall | FieldCell.BottomWall;
        builder[8, 2] = FieldCell.BottomWall | FieldCell.RightWall;
        builder[9, 2] = FieldCell.LeftWall | FieldCell.RightWall;

        builder[0, 3] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[1, 3] = FieldCell.LeftWall | FieldCell.BottomWall;
        builder[2, 3] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[3, 3] = FieldCell.TopWall;
        builder[4, 3] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[5, 3] = FieldCell.RightWall | FieldCell.BottomWall;
        builder[6, 3] = FieldCell.LeftWall;
        builder[7, 3] = FieldCell.TopWall;
        builder[8, 3] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[9, 3] = FieldCell.RightWall;

        builder[0, 4] = FieldCell.LeftWall;
        builder[1, 4] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[2, 4] = FieldCell.TopWall | FieldCell.RightWall;
        builder[3, 4] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[4, 4] = FieldCell.LeftWall | FieldCell.TopWall;
        builder[5, 4] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[6, 4] = FieldCell.BottomWall;
        builder[7, 4] = FieldCell.RightWall;
        builder[8, 4] = FieldCell.LeftWall | FieldCell.TopWall;
        builder[9, 4] = FieldCell.RightWall;

        builder[0, 5] = FieldCell.LeftWall;
        builder[1, 5] = FieldCell.TopWall | FieldCell.RightWall;
        builder[2, 5] = FieldCell.LeftWall | FieldCell.BottomWall | FieldCell.RightWall;
        builder[3, 5] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[4, 5] = FieldCell.LeftWall;
        builder[5, 5] = FieldCell.TopWall | FieldCell.RightWall;
        builder[6, 5] = FieldCell.LeftWall | FieldCell.TopWall;
        builder[7, 5] = FieldCell.RightWall;
        builder[8, 5] = FieldCell.LeftWall;
        builder[9, 5] = FieldCell.BottomWall;

        builder[0, 6] = FieldCell.Empty;
        builder[1, 6] = FieldCell.BottomWall;
        builder[2, 6] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[3, 6] = FieldCell.BottomWall;
        builder[4, 6] = FieldCell.BottomWall | FieldCell.RightWall;
        builder[5, 6] = FieldCell.LeftWall | FieldCell.BottomWall;
        builder[6, 6] = FieldCell.BottomWall;
        builder[7, 6] = FieldCell.RightWall;
        builder[8, 6] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[9, 6] = FieldCell.LeftWall | FieldCell.TopWall | FieldCell.RightWall;

        builder[0, 7] = FieldCell.LeftWall;
        builder[1, 7] = FieldCell.TopWall;
        builder[2, 7] = FieldCell.TopWall;
        builder[3, 7] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[4, 7] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[5, 7] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[6, 7] = FieldCell.TopWall | FieldCell.RightWall;
        builder[7, 7] = FieldCell.LeftWall;
        builder[8, 7] = FieldCell.Empty;
        builder[9, 7] = FieldCell.RightWall;

        builder[0, 8] = FieldCell.LeftWall;
        builder[1, 8] = FieldCell.BottomWall | FieldCell.RightWall;
        builder[2, 8] = FieldCell.LeftWall | FieldCell.RightWall;
        builder[3, 8] = FieldCell.BottomWall | FieldCell.LeftWall | FieldCell.TopWall;
        builder[4, 8] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[5, 8] = FieldCell.TopWall;
        builder[6, 8] = FieldCell.BottomWall;
        builder[7, 8] = FieldCell.BottomWall;
        builder[8, 8] = FieldCell.BottomWall | FieldCell.RightWall;
        builder[9, 8] = FieldCell.LeftWall | FieldCell.RightWall;

        builder[0, 9] = FieldCell.LeftWall | FieldCell.BottomWall | FieldCell.RightWall;
        builder[1, 9] = FieldCell.LeftWall | FieldCell.TopWall | FieldCell.BottomWall;
        builder[2, 9] = FieldCell.BottomWall;
        builder[3, 9] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[4, 9] = FieldCell.TopWall | FieldCell.RightWall;
        builder[5, 9] = FieldCell.LeftWall | FieldCell.BottomWall | FieldCell.RightWall;
        builder[6, 9] = FieldCell.LeftWall | FieldCell.TopWall | FieldCell.BottomWall;
        builder[7, 9] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[8, 9] = FieldCell.TopWall | FieldCell.BottomWall;
        builder[9, 9] = FieldCell.BottomWall | FieldCell.RightWall;
        return builder.Build();
    }

    public GameField GameField => _gameField;

    public override bool Equals(object? obj)
    {
        if (base.Equals(obj))
        {
            return Id != Guid.Empty && ((GameState)obj).Id != Guid.Empty;
        }

        return false;
    }

    // This override is needed just to remove warning about overriden Equals without GetHashCode
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}