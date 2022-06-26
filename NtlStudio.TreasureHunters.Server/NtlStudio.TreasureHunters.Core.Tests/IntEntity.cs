namespace NtlStudio.TreasureHunters.Core.Tests;

public class IntEntity: Entity<int>
{
    public IntEntity()
    {
    }

    public IntEntity(int value)
    {
        Id = value;
    }

    public override bool Equals(object? obj)
    {
        if (base.Equals(obj))
        {
            return Id != 0 && ((IntEntity)obj).Id != 0;
        }

        return false;
    }
}