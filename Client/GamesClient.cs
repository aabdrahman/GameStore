using System.Text.Json;
using GameStore.UI.Models;

namespace GameStore.UI.Client;

public class GamesClient(HttpClient httpClient)
{
    private readonly GenresClient genresClient = new(httpClient);
    private readonly List<GameSummary> games = new List<GameSummary>
    {
        new GameSummary(){Id = 1, Name = "Street Fighter II", Genre = "Fighting", Price = 19.99m, ReleaseDate = new DateOnly(1992, 7, 15)},
        new GameSummary(){Id = 2, Name = "Final Fantasy XIV", Genre = "RolePlaying", Price = 59.99m, ReleaseDate = new DateOnly(2010, 9, 30)},
        new GameSummary(){Id = 3, Name = "FIFA 23", Genre = "Sports", Price = 69.99M, ReleaseDate = new DateOnly(2022, 9, 27)}
    };

    public async Task<List<GameSummary>> GetGameSummaries()
    {
        var getDetails = await httpClient.GetAsync("GetGames");

        var content = await getDetails.Content.ReadAsStringAsync();

        var gamesDto = JsonSerializer.Deserialize<List<GameDto>>(content);

        return gamesDto.Select(x => new GameSummary() { Id = x.id, Genre = x.genre, Name = x.name, Price = x.price, ReleaseDate = x.releasedDate }).ToList() ?? [];
    }


    public async Task AddGame(GameDetails gameDetails)
    {
        var gameToInsert = new CreateGameDto()
        {
            Name = gameDetails.Name,
            GenreId = int.Parse(gameDetails.GenreId!),
            ReleasedDate = gameDetails.ReleaseDate,
            Price = gameDetails.Price,
            Company = "Test"
        };

        var response = await httpClient.PostAsJsonAsync("GetGames", gameToInsert);
    }

    public async Task<GameDetails?> GetById(int Id)
    {
        var game = await GetGameSummaryById(Id);
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

    public async Task UpdateGame(GameDetails updatedGame)
    {
        var updatedGameToApply = new CreateGameDto()
        {
            Name = updatedGame.Name,
            GenreId = int.Parse(updatedGame.GenreId ?? "0"),
            Company = "Criterion Games",
            Price = updatedGame.Price,
            ReleasedDate = updatedGame.ReleaseDate
        };

        var response = await httpClient.PutAsJsonAsync($"GetGames/{updatedGame.Id}", updatedGameToApply);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteGame(int Id)
    {
        var response = await httpClient.DeleteAsync($"GetGames/{Id}");
        response.EnsureSuccessStatusCode();
    }

    private async Task<GameSummary> GetGameSummaryById(int Id)
    {
        var response = await httpClient.GetAsync($"GetGames/{Id}");
        var stringContent = await response.Content.ReadAsStringAsync();
        var gameDto = JsonSerializer.Deserialize<GameDto>(stringContent);
        ArgumentNullException.ThrowIfNull(gameDto);
        return new GameSummary(){Id = gameDto.id, Genre = gameDto.genre, Name = gameDto.name, Price = gameDto.price, ReleaseDate = gameDto.releasedDate};
    }

    private async Task<Genre?> GetGenreById(string? Id)
    {
        ArgumentNullException.ThrowIfNull(Id);
        var response = await httpClient.GetAsync($"GetGames/{Id}");
        var content = await response.Content.ReadAsStringAsync();

        var genre = JsonSerializer.Deserialize<GenreDto>(content);
        return new Genre() { Id = genre.id, Name = genre.name };
    }
}
