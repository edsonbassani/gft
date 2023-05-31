using FluentValidation;
using Roa.Domain.Extensions;

namespace Roa.Domain.Entities;
public class Period : Entity
{
    public Period(int id, string name, TimeSpan startTime, TimeSpan endTime) // For seeding
    {
        Id = id;
        Name = name;
        StartTime = startTime;
        EndTime = endTime;
        Validate(this, new PeriodValidator());
    }

    public Period(string name)
    {
        Name = name;
        Validate(this, new PeriodValidator());
    }

    public string Name { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set;}
    public virtual ICollection<Dish> Dishes { get; private set; }
}

internal class PeriodValidator : AbstractValidator<Period>
{
    internal PeriodValidator()
    {
        RuleFor(a => a.Name)
          .NotEmpty()
          .WithMessage(ValidatorExtensions.RequiredMessage("Name"))
          .MaximumLength(50)
          .WithMessage(ValidatorExtensions.MaxLengthMessage("Name", 50));

        RuleFor(a => a.StartTime)
          .NotNull()
          .WithMessage(ValidatorExtensions.RequiredMessage("Start Time"));

        RuleFor(a => a.EndTime)
          .NotNull()
          .WithMessage(ValidatorExtensions.RequiredMessage("End Time"));
    }
}
