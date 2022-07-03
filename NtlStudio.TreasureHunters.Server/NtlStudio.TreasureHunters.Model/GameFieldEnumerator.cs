using System.Collections;

namespace NtlStudio.TreasureHunters.Game;

internal class GameFieldEnumerator: IEnumerator<IEnumerable<FieldCell>>
{
    private readonly GameField _gameField;
    
    private int _y = -1;
    
    public GameFieldEnumerator(GameField gameField)
    {
        _gameField = gameField;
    }

    public bool MoveNext()
    {
        if (_y < GameField.FieldHeight - 1)
        {
            _y++;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _y = -1;
    }

    public IEnumerable<FieldCell> Current
    {
        get
        {
            var result = new FieldCell[GameField.FieldWidth];
            for (var i = 0; i < GameField.FieldWidth; i++)
            {
                result[i] = _gameField[i, _y];
            }

            return result;
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }
}