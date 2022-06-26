namespace NtlStudio.TreasureHunters.Core.Tests;

public class TestEntity: Entity<int>
{
    public TestEntity()
    {
    }

    public TestEntity(int value)
    {
        Id = value;
    }

    public override bool Equals(object? obj)
    {
        if (base.Equals(obj))
        {
            return Id != 0 && ((TestEntity)obj).Id != 0;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}