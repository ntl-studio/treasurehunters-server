using NUnit.Framework;

namespace NtlStudio.TreasureHunters.Core.Tests;

public class EntityTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EntitiesWithTheSameIdShouldBeEqual()
    {
        // arrange
        var entity1 = new TestEntity(5);
        var entity2 = new TestEntity(5);
        
        //act, assert
        Assert.AreEqual(entity1, entity2);
    }

    [Test]
    public void EntitiesWithZeroIdShouldNotBeEqual()
    {
        // arrange
        var entity1 = new TestEntity();
        var entity2 = new TestEntity();
        
        //act, assert
        Assert.AreNotEqual(entity1, entity2);
    }

    [Test]
    public void EqualityOperatorShouldReturnTrueForEqualEntities()
    {
        // arrange
        var entity1 = new TestEntity(1);
        var entity2 = new TestEntity(1);
        
        // act
        var result = entity1 == entity2;
        
        // assert
        Assert.IsTrue(result);
    }
}