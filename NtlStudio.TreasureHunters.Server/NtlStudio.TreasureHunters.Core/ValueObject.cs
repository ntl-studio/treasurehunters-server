namespace NtlStudio.TreasureHunters.Core;

public abstract class ValueObject<T> where T: ValueObject<T>
{
    public override bool Equals(object? obj)
    {
        var valueObj = obj as T;

        if (ReferenceEquals(valueObj, null))
            return true;

        return EqualsValueObject(valueObj);
    }

    protected abstract bool EqualsValueObject(T other);

    public override int GetHashCode()
    {
        return GetValueObjectHashCode();
    }

    protected abstract int GetValueObjectHashCode();

    public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
    {
        return !(a == b);
    }
}