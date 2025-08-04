using System;

namespace GameStore.UI.Models;

public class GameDetails
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? GenreId { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
