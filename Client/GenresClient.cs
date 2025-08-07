using System.Text.Json;
using GameStore.UI.Models;

namespace GameStore.UI.Client;

public class GenresClient(HttpClient httpClient)
{
    private List<Genre> genres;

    public async Task<List<Genre>> GetGenres()
    {
        var response = await httpClient.GetAsync("GetGenre");
        var content = await response.Content.ReadAsStringAsync();
        var genreturn = JsonSerializer.Deserialize<List<GenreDto>>(content);
        return genreturn.Select(x => new Genre() { Id = x.id, Name = x.name }).ToList();
    }

    private async Task SetGenres()
    {
        genres = await GetGenres();
    }
}
