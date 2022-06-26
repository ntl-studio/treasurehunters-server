using NtlStudio.TreasureHunters.Core;

namespace NtlStudio.TreasureHunters.Game;

public class GameState: Entity<Guid>
{
    public GameState(Guid gameId)
    {
        Id = gameId;
        GameField = new FieldCell[10, 10];
        GenerateDefaultGameField(GameField);
    }

    private void GenerateDefaultGameField(FieldCell[,] gameField)
    {
        gameField[0, 0] = FieldCell.LeftWall | FieldCell.TopWall;
        gameField[1, 0] = FieldCell.TopWall | FieldCell.RightWall | FieldCell.BottomWall;
        gameField[2, 0] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[3, 0] = FieldCell.LeftWall | FieldCell.TopWall;
        gameField[4, 0] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[5, 0] = FieldCell.TopWall;
        gameField[6, 0] = FieldCell.TopWall;
        gameField[7, 0] = FieldCell.TopWall;
        gameField[8, 0] = FieldCell.TopWall;
        gameField[9, 0] = FieldCell.TopWall | FieldCell.RightWall;

        gameField[0, 1] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[1, 1] = FieldCell.LeftWall | FieldCell.TopWall;
        gameField[2, 1] = FieldCell.RightWall | FieldCell.BottomWall;
        gameField[3, 1] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[4, 1] = FieldCell.LeftWall | FieldCell.TopWall | FieldCell.RightWall;
        gameField[5, 1] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[6, 1] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[7, 1] = FieldCell.LeftWall | FieldCell.BottomWall | FieldCell.RightWall;
        gameField[8, 1] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[9, 1] = FieldCell.LeftWall | FieldCell.RightWall;

        gameField[0, 2] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[1, 2] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[2, 2] = FieldCell.TopWall | FieldCell.LeftWall | FieldCell.BottomWall;
        gameField[3, 2] = FieldCell.BottomWall;
        gameField[4, 2] = FieldCell.BottomWall | FieldCell.RightWall;
        gameField[5, 2] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[6, 2] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[7, 2] = FieldCell.LeftWall | FieldCell.TopWall | FieldCell.BottomWall;
        gameField[8, 2] = FieldCell.BottomWall | FieldCell.RightWall;
        gameField[9, 2] = FieldCell.LeftWall | FieldCell.RightWall;

        gameField[0, 3] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[1, 3] = FieldCell.LeftWall | FieldCell.BottomWall;
        gameField[2, 3] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[3, 3] = FieldCell.TopWall;
        gameField[4, 3] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[5, 3] = FieldCell.RightWall | FieldCell.BottomWall;
        gameField[6, 3] = FieldCell.LeftWall;
        gameField[7, 3] = FieldCell.TopWall;
        gameField[8, 3] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[9, 3] = FieldCell.RightWall;

        gameField[0, 4] = FieldCell.LeftWall;
        gameField[1, 4] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[2, 4] = FieldCell.TopWall | FieldCell.RightWall;
        gameField[3, 4] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[4, 4] = FieldCell.LeftWall | FieldCell.TopWall;
        gameField[5, 4] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[6, 4] = FieldCell.BottomWall;
        gameField[7, 4] = FieldCell.RightWall;
        gameField[8, 4] = FieldCell.LeftWall | FieldCell.TopWall;
        gameField[9, 4] = FieldCell.RightWall;

        gameField[0, 5] = FieldCell.LeftWall;
        gameField[1, 5] = FieldCell.TopWall | FieldCell.RightWall;
        gameField[2, 5] = FieldCell.LeftWall | FieldCell.BottomWall | FieldCell.RightWall;
        gameField[3, 5] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[4, 5] = FieldCell.LeftWall;
        gameField[5, 5] = FieldCell.TopWall | FieldCell.RightWall;
        gameField[6, 5] = FieldCell.LeftWall | FieldCell.TopWall;
        gameField[7, 5] = FieldCell.RightWall;
        gameField[8, 5] = FieldCell.LeftWall;
        gameField[9, 5] = FieldCell.BottomWall;

        gameField[0, 6] = FieldCell.Empty;
        gameField[1, 6] = FieldCell.BottomWall;
        gameField[2, 6] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[3, 6] = FieldCell.BottomWall;
        gameField[4, 6] = FieldCell.BottomWall | FieldCell.RightWall;
        gameField[5, 6] = FieldCell.LeftWall | FieldCell.BottomWall;
        gameField[6, 6] = FieldCell.BottomWall;
        gameField[7, 6] = FieldCell.RightWall;
        gameField[8, 6] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[9, 6] = FieldCell.LeftWall | FieldCell.TopWall | FieldCell.RightWall;

        gameField[0, 7] = FieldCell.LeftWall;
        gameField[1, 7] = FieldCell.TopWall;
        gameField[2, 7] = FieldCell.TopWall;
        gameField[3, 7] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[4, 7] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[5, 7] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[6, 7] = FieldCell.TopWall | FieldCell.RightWall;
        gameField[7, 7] = FieldCell.LeftWall;
        gameField[8, 7] = FieldCell.Empty;
        gameField[9, 7] = FieldCell.RightWall;

        gameField[0, 8] = FieldCell.LeftWall;
        gameField[1, 8] = FieldCell.BottomWall | FieldCell.RightWall;
        gameField[2, 8] = FieldCell.LeftWall | FieldCell.RightWall;
        gameField[3, 8] = FieldCell.BottomWall | FieldCell.LeftWall | FieldCell.TopWall;
        gameField[4, 8] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[5, 8] = FieldCell.TopWall;
        gameField[6, 8] = FieldCell.BottomWall;
        gameField[7, 8] = FieldCell.BottomWall;
        gameField[8, 8] = FieldCell.BottomWall | FieldCell.RightWall;
        gameField[9, 8] = FieldCell.LeftWall | FieldCell.RightWall;

        gameField[0, 9] = FieldCell.LeftWall | FieldCell.BottomWall | FieldCell.RightWall;
        gameField[1, 9] = FieldCell.LeftWall | FieldCell.TopWall | FieldCell.BottomWall;
        gameField[2, 9] = FieldCell.BottomWall;
        gameField[3, 9] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[4, 9] = FieldCell.TopWall | FieldCell.RightWall;
        gameField[5, 9] = FieldCell.LeftWall | FieldCell.BottomWall | FieldCell.RightWall;
        gameField[6, 9] = FieldCell.LeftWall | FieldCell.TopWall | FieldCell.BottomWall;
        gameField[7, 9] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[8, 9] = FieldCell.TopWall | FieldCell.BottomWall;
        gameField[9, 9] = FieldCell.BottomWall | FieldCell.RightWall;
    }

    public FieldCell[,] GameField { get; }

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