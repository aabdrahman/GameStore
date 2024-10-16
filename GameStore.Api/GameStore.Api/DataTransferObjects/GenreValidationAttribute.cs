using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace GameStore.Api.DataTransferObjects;

public class GenreValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var genreName = value as string;

        var genres = new List<string>()
        {
            "Sports",
            "Racing",
            "Adventure",
            "First-Person Shooter",
            "Fighting"
        };

        if (!genres.Contains(genreName))
            return new ValidationResult($"The provided genre: {genreName} is not valid!");
        
        return ValidationResult.Success;
    }
}

