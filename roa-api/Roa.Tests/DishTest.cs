using Bogus;
using Roa.Domain.Entities;
using Xunit;

namespace Roa.Tests.Entities;
public class DishTest
{
    [Fact]
    [Trait("Dish", "Should_Create_Valid_Dish_Instance")]
    public void Should_Create_Valid_Dish_Instance()
    {
        // arrange
        var faker = new Faker();

        // act
        var dish = new Dish(faker.Random.Int(), faker.Random.String(20), 1, 1);

        // assert
        Assert.False(dish.Invalid);
    }

    [Fact]
    [Trait("Dish", "Should_Create_Invalid_Dish_Instance")]
    public void Should_Create_Invalid_Dish_Instance()
    {
        // arrange
        var faker = new Faker();

        // act
        var dish = new Dish(faker.Random.Int(), faker.Random.String(500), 1, 1);

        // assert
        var validResult = dish.ValidationResult.Errors.FirstOrDefault();

        Assert.True(dish.Invalid);
        Assert.Equal("Name should be equal or less than 50 characters", validResult?.ErrorMessage);
    }
}
