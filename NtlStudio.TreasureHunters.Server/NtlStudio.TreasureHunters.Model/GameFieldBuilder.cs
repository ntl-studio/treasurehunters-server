using System.Collections.ObjectModel;
using NtlStudio.TreasureHunters.Game.Exceptions;
using NtlStudio.TreasureHunters.Game.Validators;

namespace NtlStudio.TreasureHunters.Game;

public class GameFieldBuilder
{
    private readonly FieldCell[,] _field;
    private readonly Collection<IFieldValidator> _fieldValidators = new Collection<IFieldValidator>();

    public GameFieldBuilder(int width, int height)
    {
        _field = new FieldCell[width, height];
        Init(ref _field);
        AddValidator(new ExitValidator());
    }

    private void Init(ref FieldCell[,] field)
    {
        for(var x = 0; x < field.GetLength(0); x++)
        {
            for(var y = 0; y < field.GetLength(1); y++)
            {
                field[x, y] = FieldCell.Empty;
                if ((x, y) is (0, _))
                    field[x, y] |= FieldCell.LeftWall;
                if ((x, y) is (GameField.FieldWidth - 1, _))
                    field[x, y] |= FieldCell.RightWall;
                if ((x, y) is (_, 0))
                    field[x, y] |= FieldCell.TopWall;
                if ((x, y) is (_, GameField.FieldHeight - 1))
                    field[x, y] |= FieldCell.BottomWall;
            }
        }
    }

    public FieldCell this[int x, int y]
    {
        get => _field[x, y];
        set
        {
            AdjustCellsAround(x, y, value);
            _field[x, y] = value;
        }
    }

    public void AddValidator(IFieldValidator validator)
    {
        _fieldValidators.Add(validator);
    }

    private void AdjustCellsAround(int x, int y, FieldCell value)
    {
        foreach (FieldCell wall in Enum.GetValues(typeof(FieldCell)))
        {
            if (value.HasFlag(wall))
            {
                EnsureSiblingWall(x, y, wall);
            }
        }
    }

    private void EnsureSiblingWall(int x, int y, FieldCell wall)
    {
        switch (wall)
        {
            case FieldCell.RightWall:
                if (x < _field.GetLength(0) - 1)
                    _field[x + 1, y] |= FieldCell.LeftWall;
                break;
            case FieldCell.LeftWall:
                if (x > 0)
                    _field[x - 1, y] |= FieldCell.RightWall;
                break;
            case FieldCell.BottomWall:
                if (y < _field.GetLength(1) - 1)
                    _field[x, y + 1] |= FieldCell.TopWall;
                break;
            case FieldCell.TopWall:
                if (y > 0)
                    _field[x, y - 1] |= FieldCell.BottomWall;
                break;
        }
    }

    public GameField Build()
    {
        Validate(_field);
        return new GameField(_field);
    }

    private void Validate(FieldCell[,] field)
    {
        foreach (var fieldValidator in _fieldValidators)
        {
            if (!fieldValidator.Validate(field, out var errors))
            {
                throw new ModelException(errors[0]);
            }
        }
    }
}