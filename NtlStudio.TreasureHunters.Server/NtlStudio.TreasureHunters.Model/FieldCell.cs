namespace NtlStudio.TreasureHunters.Game;

[Flags]
public enum FieldCell: int
{
   Empty =              0b0000_0000_0000_0000,
   RightWall =          0b0000_0000_0000_0001,
   LeftWall =           0b0000_0000_0000_0010,
   BottomWall =         0b0000_0000_0000_0100,
   TopWall =            0b0000_0000_0000_1000,
   Player =             0b0000_0000_0001_0000,
   Enemy =              0b0000_0000_0010_0000,
   Crossbow =           0b0000_0000_0100_0000,
   BulletproofVest =    0b0000_0000_1000_0000,
   AidKit =             0b0000_0001_0000_0000,
   Trap =               0b0000_0010_0000_0000,
   Treasure =           0b0000_0100_0000_0000,
}