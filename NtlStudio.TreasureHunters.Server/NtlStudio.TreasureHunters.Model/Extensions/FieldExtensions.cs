namespace NtlStudio.TreasureHunters.Game.Extensions;

public static class FieldExtensions
{
    public static FieldCell[] GetRow(this FieldCell[,] field, int y)
    {
        var row = new FieldCell[field.GetLength(0)];
        for (var x = 0; x < field.GetLength(0); x++)
        {
            row[x] = field[x, y];
        }

        return row;
    }
    
    public static FieldCell[] GetColumn(this FieldCell[,] field, int x)
    {
        var column = new FieldCell[field.GetLength(1)];
        for (var y = 0; y < field.GetLength(1); y++)
        {
            column[y] = field[x, y];
        }

        return column;
    }
}