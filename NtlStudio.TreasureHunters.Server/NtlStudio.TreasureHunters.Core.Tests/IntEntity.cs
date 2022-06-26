namespace NtlStudio.TreasureHunters.Core;

public class IntEntity: Entity<int>
{
    public IntEntity()
    {
    }

    public IntEntity(int value)
    {
        Id = value;
    }
}