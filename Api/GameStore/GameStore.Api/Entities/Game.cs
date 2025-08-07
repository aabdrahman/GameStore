using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Entities;

public class Game
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public decimal Price { get; set; }
    public DateOnly ReleasedDate { get; set; }

    public required string Company {get; set;}

    public int GenreId { get; set; }
    public Genre? genre {get; set;}
}
