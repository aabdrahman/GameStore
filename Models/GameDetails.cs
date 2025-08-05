using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.UI.Models;

public class GameDetails
{
    public int Id { get; set; }
    [Required, Display(Name = "Game Name"), StringLength(50)]
    public string Name { get; set; }
    [Required(ErrorMessage = "Genre is a required field")]
    public string? GenreId { get; set; }
    [Required, Range(1, 100)]
    public decimal Price { get; set; }
    [Required]
    public DateOnly ReleaseDate { get; set; }
}
