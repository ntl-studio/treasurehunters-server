using NtlStudio.TreasureHunters.Core;

namespace NtlStudio.TreasureHunters.Game;

public class User: ValueObject<User>
{
    public User(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; set; }

    protected override bool EqualsValueObject(User other)
    {
        return other.UserName == UserName;
    }

    protected override int GetValueObjectHashCode()
    {
        return UserName.GetHashCode();
    }
}