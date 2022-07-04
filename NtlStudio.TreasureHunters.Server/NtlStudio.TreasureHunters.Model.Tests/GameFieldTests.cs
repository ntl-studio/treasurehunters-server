using System;
using NtlStudio.TreasureHunters.Game;
using NtlStudio.TreasureHunters.Game.Exceptions;
using NUnit.Framework;

namespace NtlStudio.TreasureHunters.Mode.Tests;

public class GameFieldTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GameFieldHasOnlyOneExitOnEachSide()
    {
        // arrange
        var builder = new GameFieldBuilder(10, 10)
        {
            [5, 0] = FieldCell.Empty,
            [0, 5] = FieldCell.Empty,
            [9, 5] = FieldCell.Empty,
            [5, 9] = FieldCell.Empty
        };

        // act
        var field = builder.Build();

        // assert
        var leftExitsAmount = 0;
        var rightExitsAmount = 0;
        for (int i = 0; i < GameField.FieldHeight; i++)
        {
            if (!field[0, i].HasFlag(FieldCell.LeftWall))
                leftExitsAmount++;
            if (!field[GameField.FieldWidth - 1, i].HasFlag(FieldCell.RightWall))
                            rightExitsAmount++;
        }

        Assert.AreEqual(1, leftExitsAmount, "Left exits amount is not 1");
        Assert.AreEqual(1, rightExitsAmount, "Right exits amount is not 1");
        
        var topExitsAmount = 0;
        var bottomExitsAmount = 0;
        for (int i = 0; i < GameField.FieldWidth; i++)
        {
            if (!field[i, 0].HasFlag(FieldCell.TopWall))
                topExitsAmount++;
            if (!field[i, GameField.FieldHeight - 1].HasFlag(FieldCell.BottomWall))
                bottomExitsAmount++;
        }
        
        Assert.AreEqual(1, topExitsAmount, "Top exits amount is not 1");
        Assert.AreEqual(1, bottomExitsAmount, "Bottom exits amount is not 1");
    }
    
    [TestCase(FieldCell.LeftWall | FieldCell.RightWall | FieldCell.BottomWall)]
    [TestCase(FieldCell.LeftWall | FieldCell.RightWall | FieldCell.TopWall)]
    [TestCase(FieldCell.BottomWall | FieldCell.RightWall | FieldCell.TopWall)]
    [TestCase(FieldCell.BottomWall | FieldCell.LeftWall | FieldCell.TopWall)]
    public void CannotCreateFieldWithoutFourExists(FieldCell exitSides)
    {
        // arrange
        var builder = new GameFieldBuilder(GameField.FieldWidth, GameField.FieldHeight);
        
        // act
        Random random = new Random();
        if (exitSides.HasFlag(FieldCell.LeftWall))
        {
            var y = random.Next(GameField.FieldHeight - 1);
            builder[0, y] = FieldCell.Empty;
        }

        if (exitSides.HasFlag(FieldCell.RightWall))
        {
            var y = random.Next(GameField.FieldHeight - 1);
            builder[GameField.FieldWidth - 1, y] = FieldCell.Empty;
        }

        if (exitSides.HasFlag(FieldCell.TopWall))
        {
            var x = random.Next(GameField.FieldWidth - 1);
            builder[x, 0] = FieldCell.Empty;
        }

        if (exitSides.HasFlag(FieldCell.BottomWall))
        {
            var x = random.Next(GameField.FieldWidth - 1);
            builder[x, GameField.FieldHeight - 1] = FieldCell.Empty;
        }
        
        // assert
        try
        {
            builder.Build();
        }
        catch (Exception e)
        {
            Assert.Pass();
        }
        Assert.Fail("Field is created without four exits");
    }
}