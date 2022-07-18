using System.Collections;
using NtlStudio.TreasureHunters.Core;

namespace NtlStudio.TreasureHunters.Game;

public class GameField: ValueObject<GameField>, IEnumerable<IEnumerable<FieldCell>>
{
    public const int FieldWidth = 10;
    public const int FieldHeight = 10;
    public const int MaxUsers = 5;
    private readonly FieldCell[,] _gameField;

    internal GameField(FieldCell[,] field)
    {
        _gameField = field;
    }

    public FieldCell this[int x, int y] => _gameField[x, y];

    protected override bool EqualsValueObject(GameField other)
    {
        for (var i = 0; i < FieldWidth; i++)
            for (var j = 0; j < FieldHeight; j++)
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

    public IEnumerator<IEnumerable<FieldCell>> GetEnumerator()
    {
        return new GameFieldEnumerator(new GameField(_gameField));
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}