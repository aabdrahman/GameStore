using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DataTransferObjects;

public class ReleasedDateValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateOnly)
            return ValidationResult.Success;
        
        var ProvidedReleasedDate = value as string;

        if(!DateOnly.TryParse(ProvidedReleasedDate, out DateOnly result))
            return new ValidationResult("The provided date is invalid");

        return ValidationResult.Success;
    }
}

