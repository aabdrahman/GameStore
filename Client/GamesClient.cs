using System.Runtime.CompilerServices;
using GameStore.UI.Models;

namespace GameStore.UI.Client;

public class GamesClient
{
    private readonly GenresClient genresClient = new();
    private readonly List<GameSummary> games = new List<GameSummary>
    {
        new GameSummary(){Id = 1, Name = "Street Fighter II", Genre = "Fighting", Price = 19.99m, ReleaseDate = new DateOnly(1992, 7, 15)},
        new GameSummary(){Id = 2, Name = "Final Fantasy XIV", Genre = "RolePlaying", Price = 59.99m, ReleaseDate = new DateOnly(2010, 9, 30)},
        new GameSummary(){Id = 3, Name = "FIFA 23", Genre = "Sports", Price = 69.99M, ReleaseDate = new DateOnly(2022, 9, 27)}
    };

    public List<GameSummary> GetGameSummaries() => games;
    public void AddGame(GameDetails gameDetails)
    {
        var gameToInsert = new GameSummary()
        {
            Id = games.Count + 1,
            Name = gameDetails.Name,
            Genre = genresClient.GetGenres().FirstOrDefault(x => x.Id == Convert.ToInt32(gameDetails.GenreId))?.Name ?? throw new ArgumentNullException(nameof(Genre), $"Invalid Genre Id."),
            ReleaseDate = gameDetails.ReleaseDate,
            Price = gameDetails.Price
        };
        games.Add(gameToInsert);
    }
}
