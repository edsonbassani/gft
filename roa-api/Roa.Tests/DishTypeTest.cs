using Bogus;
using Roa.Domain.Entities;
using Xunit;

namespace Roa.Tests.Entities;
public class DishTypeTest
{
    [Fact]
    [Trait("DishType", "Should_Create_Valid_DishType_Instance")]
    public void Should_Create_Valid_DishType_Instance()
    {
        // arrange
        var faker = new Faker();

        // act
        var dishType = new DishType(faker.Random.Int(), faker.Random.String(20));

        // assert
        Assert.False(dishType.Invalid);
    }

    [Fact]
    [Trait("DishType", "Should_Create_Invalid_DishType_Instance")]
    public void Should_Create_Invalid_DishType_Instance()
    {
        // arrange
        var faker = new Faker();

        // act
        var dishType = new DishType(faker.Random.Int(), faker.Random.String(500));

        // assert
        var validResult = dishType.ValidationResult.Errors.FirstOrDefault();

        Assert.True(dishType.Invalid);
        Assert.Equal("Name should be equal or less than 50 characters", validResult?.ErrorMessage);
    }
}
