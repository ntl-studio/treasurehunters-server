namespace NtlStudio.TreasureHunters.Core;

public interface IEntity<out TId>
{
    TId? Id { get; }
}