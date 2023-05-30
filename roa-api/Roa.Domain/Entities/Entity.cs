using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Roa.Domain.Entities;
public abstract class Entity
{
    public int Id { get; protected set; }

    [NotMapped]
    [JsonIgnore]
    public bool Valid { get; private set; }

    [NotMapped]
    [JsonIgnore]
    public bool Invalid => !Valid;

    [NotMapped]
    [JsonIgnore]
    public ValidationResult ValidationResult { get; private set; }

    public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
    {
        ValidationResult = validator.Validate(model);
        return Valid = ValidationResult.IsValid;
    }
}
