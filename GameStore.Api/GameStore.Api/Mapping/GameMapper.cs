using System;
using GameStore.Api.DataTransferObjects;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GameMapper
{
    public static Game ToEntity(this CreateGameDTO game)
    {
        return new Game ()
        {
            Name = game.Name,
            ReleasedDate = game.ReleasedDate,
            Price = game.Price,
            GenreId = game.GenreId,
            Company = game.Company
        };
    }

    public static Game ToEntity(this UpdateGameDTO game, int id)
    {
        return new Game ()
        {
            Id = id,
            Name = game.Name,
            ReleasedDate = game.ReleasedDate,
            Price = game.Price,
            GenreId = game.GenreId,
            Company = game.Company
        };
    }

    public static GameSummaryDTO ToGameSummaryDTO(this Game game)
    {
        return new GameSummaryDTO
        (
            Id: game.Id,
            Name: game.Name,
            Company: game.Company,
            ReleasedDate: game.ReleasedDate,
            Price: game.Price,
            Genre: game.genre!.Name
        );
    }

    public static GameDetailsDTO ToGameDetails(this Game game)
    {
        return new GameDetailsDTO
        (
            Id: game.Id,
            Name: game.Name,
            Company: game.Company,
            ReleasedDate: game.ReleasedDate,
            Price: game.Price,
            GenreId: game.GenreId
        );
    }
}
