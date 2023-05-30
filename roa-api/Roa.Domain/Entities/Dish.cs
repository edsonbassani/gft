using FluentValidation;
using Roa.Domain.Extensions;

namespace Roa.Domain.Entities;
public class Dish : Entity
{
    public Dish(int id, string name, int dishTypeId, int periodId)
    {
        Id = id;
        Name = name;
        DishTypeId = dishTypeId;
        PeriodId = periodId;
        //Validate(this, new DishValidator());
    }

    public string Name { get; private set; }
    public int DishTypeId { get; private set; }
    public DishType DishType { get; private set; }
    public int PeriodId { get; private set;}
    public Period Period { get; private set; }

}

internal class DishValidator : AbstractValidator<Dish>
{
    internal DishValidator()
    {
        RuleFor(a => a.Name)
          .NotEmpty()
          .WithMessage(ValidatorExtensions.RequiredMessage("Name"))
          .MaximumLength(50)
          .WithMessage(ValidatorExtensions.MaxLengthMessage("Name", 50));

        RuleFor(a => a.DishTypeId)
          .NotNull()
          .WithMessage(ValidatorExtensions.RequiredMessage("DishTypeId"));

        RuleFor(a => a.PeriodId)
          .NotNull()
          .WithMessage(ValidatorExtensions.RequiredMessage("PeriodId"));
    }
}
