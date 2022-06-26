namespace NtlStudio.TreasureHunters.Core;

public abstract class Entity<TId>: IEntity<TId>
{
    public TId? Id { get; protected init; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        if (Id == null || other.Id == null)
            return false;
        
        return Id.Equals(other.Id);
    }

    public static bool operator ==(Entity<TId> a, Entity<TId> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return false;

        return a!.Equals(b);
    }

    public static bool operator !=(Entity<TId> a, Entity<TId> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType() + ":" + Id).GetHashCode();
    }
}