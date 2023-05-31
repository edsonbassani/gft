using Bogus;
using Roa.Domain.Entities;
using Xunit;

namespace Roa.Tests.Entities;
public class PeriodTest
{
    [Fact]
    [Trait("Period", "Should_Create_Valid_Period_Instance")]
    public void Should_Create_Valid_Period_Instance()
    {
        // arrange
        var faker = new Faker();

        // act
        var period = new Period(faker.Random.Int(), faker.Random.String(20), DateTime.Now.TimeOfDay, DateTime.Now.TimeOfDay);

        // assert
        Assert.False(period.Invalid);
    }

    [Fact]
    [Trait("Period", "Should_Create_Invalid_Period_Instance")]
    public void Should_Create_Invalid_Period_Instance()
    {
        // arrange
        var faker = new Faker();

        // act
        var period = new Period(faker.Random.Int(), faker.Random.String(500), DateTime.Now.TimeOfDay, DateTime.Now.TimeOfDay);

        // assert
        var validResult = period.ValidationResult.Errors.FirstOrDefault();

        Assert.True(period.Invalid);
        Assert.Equal("Name should be equal or less than 50 characters", validResult?.ErrorMessage);
    }
}
