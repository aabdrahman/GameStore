using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DataTransferObjects;

public record class UpdateGameDTO
(
    [Required]
    [StringLength(50 ,MinimumLength = 2, ErrorMessage = "Name length must be between 2 and 50 characters")]
    string Name,

    int GenreId,

    [Required]
    [MaxLength(50)]
    string Company,

    [Required]
    decimal Price,

    [ReleasedDateValidation]
    [Required]
    DateOnly ReleasedDate
);
