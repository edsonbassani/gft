using FluentValidation;
using Roa.Domain.Extensions;

namespace Roa.Domain.Entities;
public class DishType : Entity
{
    public DishType(int id, string name) // For seeding
    {
        Id = id;
        Name = name;
        Validate(this, new DishTypeValidator());
    }

    public string Name { get; private set; }
    public virtual ICollection<Dish> Dishes { get; set; }
}

internal class DishTypeValidator : AbstractValidator<DishType>
{
    internal DishTypeValidator()
    {
        RuleFor(a => a.Name)
          .NotEmpty()
          .WithMessage(ValidatorExtensions.RequiredMessage("Name"))
          .MaximumLength(50)
          .WithMessage(ValidatorExtensions.MaxLengthMessage("Name", 50));
    }
}
