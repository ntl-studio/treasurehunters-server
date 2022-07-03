namespace NtlStudio.TreasureHunters.Game.Validators;

public interface IFieldValidator
{
    bool Validate(FieldCell[,] field, out string[] errors);
}