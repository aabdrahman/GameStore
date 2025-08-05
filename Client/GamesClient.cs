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
            Genre = GetGenreById(gameDetails?.GenreId)?.Name,
            ReleaseDate = gameDetails.ReleaseDate,
            Price = gameDetails.Price
        };
        games.Add(gameToInsert);
    }

    public GameDetails? GetById(int Id)
    {
        var game = GetGameSummaryById(Id);
        var genre = GetGenreById(game.Id.ToString());

        return new GameDetails()
        {
            Id = game.Id,
            Name = game.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
            GenreId = genre?.Id.ToString()
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        var existingGame = GetGameSummaryById(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
        existingGame.Genre = updatedGame.Name;
    }

    public void DeleteGame(int Id)
    {
        var game = GetGameSummaryById(Id);
        games.Remove(game);
    }

    private GameSummary GetGameSummaryById(int Id)
    {
        GameSummary? gameSummary = games.Find(x => x.Id == Id);
        ArgumentNullException.ThrowIfNull(gameSummary);
        return gameSummary;
    }

    private Genre? GetGenreById(string? Id)
    {
        ArgumentNullException.ThrowIfNull(Id);
        return genresClient.GetGenres().SingleOrDefault(x => x.Id == int.Parse(Id));
    }
}
