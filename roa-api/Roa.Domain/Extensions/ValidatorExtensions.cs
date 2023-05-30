
namespace Roa.Domain.Extensions;
public static class ValidatorExtensions
{
    public static string RequiredMessage(string property) => $"{property} is required";
    public static string MaxLengthMessage(string property, int maxLength) => $"{property} should be equal or less than {maxLength} characters";
    public static string ValidDateTime(string property) => $"{property} should be a valid date";
    public static string ValidateUrl(string property) => $"{property} should be a valid Url";
}
