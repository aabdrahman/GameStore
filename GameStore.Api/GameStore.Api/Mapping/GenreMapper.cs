using System;
using GameStore.Api.DataTransferObjects;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GenreMapper
{
    public static Genre ToEntity(this GenreDTO genreDTO)
    {
        return new Genre()
        {
            Id = genreDTO.Id,
            Name = genreDTO.Genre
        };
    }

    public static Genre ToEntity(this CreateGenreDTO createGenreDTO)
    {
        return new Genre()
        {
            Name = createGenreDTO.GenreName
        };
    }

    public static GenreDTO ToDTO(this Genre genre)
    {
        return new GenreDTO
        (
            Id: genre.Id,
            Genre: genre.Name
        );
    }
}
