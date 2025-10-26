
using System.ComponentModel.DataAnnotations;

namespace ApiWithSwagger.Validations;

public class AgeValidation : ValidationAttribute
{
    private readonly int _age;

    public AgeValidation(int age)
    {
        _age = age;
        ErrorMessage = $"Åldern måste vara minst {_age} år";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int age && age >= _age)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage);
    }
}