using NtlStudio.TreasureHunters.Core;

namespace NtlStudio.TreasureHunters.Game;

public class GameField: ValueObject<GameField>
{
    private const int FieldWidth = 10;
    private const int FieldHight = 10;
    private readonly FieldCell[,] _gameField;
    
    public FieldCell this[int x, int y] => _gameField[x, y];

    protected override bool EqualsValueObject(GameField other)
    {
        for (var i = 0; i < FieldWidth; i++)
            for (var j = 0; j < FieldHight; j++)
                if (_gameField[i, j] != other[i, j])
                    return false;

        return true;
    }

    protected override int GetValueObjectHashCode()
    {
        int hc = _gameField.Length;
        foreach (var fieldCell in _gameField)
        {
            var val = (int)fieldCell;
            hc = unchecked(hc * 397 + val);
        }

        return hc;
    }
}