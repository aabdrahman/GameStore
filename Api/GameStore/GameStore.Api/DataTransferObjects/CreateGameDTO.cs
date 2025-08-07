using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DataTransferObjects;

public record class CreateGameDTO
(
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name length must be between 2 and 100", MinimumLength = 2)]
    string Name,

    int GenreId,

    [Required(ErrorMessage = "Company Name is required.")]
    [StringLength(100, ErrorMessage = "Company length must be between 2 and 100", MinimumLength = 2)]
    string Company,

    decimal Price,

    [ReleasedDateValidation]
    [Required(ErrorMessage = "Released Date must be provided.")]
    DateOnly ReleasedDate
);
