using System;

namespace GameStore.UI.Models;

public class GameSummary
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Genre { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}

public class GameDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string genre { get; set; }
    public string company { get; set; }
    public decimal price { get; set; }
    public DateOnly releasedDate { get; set; }
}