using NtlStudio.TreasureHunters.Game.Extensions;

namespace NtlStudio.TreasureHunters.Game.Validators;

public class ExitValidator: IFieldValidator
{
    public bool Validate(FieldCell[,] field, out string[] errors)
    {
        List<string> errorList = new List<string>();
        CheckFieldSide(field.GetColumn(0), FieldCell.LeftWall,  errorList);
        CheckFieldSide(field.GetColumn(field.GetLength(0) - 1), FieldCell.RightWall, errorList);
        CheckFieldSide(field.GetRow(0), FieldCell.TopWall, errorList);
        CheckFieldSide(field.GetRow(field.GetLength(1) - 1), FieldCell.BottomWall, errorList);

        errors = errorList.ToArray();
        return errorList.Count == 0;
    }

    private static void CheckFieldSide(FieldCell[] side, FieldCell exitWall, List<string> errorList)
    {
        var exitAmount = 0;
        foreach (var cell in side)
        {
            if (!cell.HasFlag(exitWall))
                exitAmount++;
        }

        if (exitAmount != 1)
            errorList.Add($"Wrong amount of exits ({exitAmount}) on {exitWall} side");
    }
}