using System;
using GameStore.UI.Models;

namespace GameStore.UI.Client;

public class GenresClient
{
    private readonly List<Genre> genres =
    [
        new Genre(){Id = 1, Name = "Fighting"},
        new Genre(){Id = 2, Name = "RolePlaying"},
        new Genre(){Id = 3, Name = "Sports"},
        new Genre(){Id = 4, Name = "Racing"},
        new Genre(){Id = 5, Name = "Kids and Family"}
    ];

    public List<Genre> GetGenres() => genres;
}
