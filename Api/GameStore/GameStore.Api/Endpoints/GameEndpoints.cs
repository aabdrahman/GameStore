using System;
using System.ComponentModel.DataAnnotations;
using GameStore.Api.Data;
using GameStore.Api.DataTransferObjects;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    static bool IsValid<T>(T obj, out ICollection<ValidationResult> results) where T : class
    {
        ValidationContext validationContext = new ValidationContext(obj);
        results = new List<ValidationResult>();

        return Validator.TryValidateObject(obj, validationContext, results);
    }

    public static RouteGroupBuilder RunGameEndpoints(this WebApplication app)
    {
        var EndPointGroup = app.MapGroup("GetGames").WithParameterValidation();

        EndPointGroup.MapGet("/", async (GameStoreContext context) => 
        {
            //var dv = context.Games.Select(g => new {Name = g.Name, Company = g.Company, Price = g.Price, ReleasedDate = g.ReleasedDate, Genre = g.genre!.Name}).ToList();
            return await context.Games
                        .Include(g => g.genre)
                        .Select(g => g.ToGameSummaryDTO())
                        .ToListAsync();

        });

        EndPointGroup.MapGet("/{id}", async (int id, GameStoreContext context) => 
        {
            var game = await context.Games.FindAsync(id);

            return game is null ? Results.NotFound($"Game with Id: {id} does not exist") : Results.Ok(game.ToGameDetails());

        }).WithName("GetGamesById");

        EndPointGroup.MapDelete("/{id}", async (int id, GameStoreContext context) => 
        {
            
            var game = await context.Games.SingleOrDefaultAsync(g => g.Id == id);

            if(game is null)
            {
                return Results.NotFound($"There is no game with the Id: {id}");
            }
                
            context.Entry(game).State = EntityState.Deleted;

            //context.Games.Remove(game);

            await context.SaveChangesAsync();


            return Results.NoContent();

        });

        EndPointGroup.MapPut("/{id}", async (int id, UpdateGameDTO updateGame, GameStoreContext context) => 
        {
            if(!IsValid(updateGame, out var validationResults))
                return Results.BadRequest(validationResults);
            
            var existingGame = await context.Games.FindAsync(id);

            if(existingGame is null)
            {
                return Results.NotFound($"There is no game with specified Id: {id}");
            }

            context.Entry(existingGame)
                .CurrentValues
                .SetValues(updateGame.ToEntity(id));
            
            await context.SaveChangesAsync();

            return Results.NoContent();

        });

        EndPointGroup.MapPost("/", async (CreateGameDTO NewGame, GameStoreContext context) =>
        {
            if(!IsValid(NewGame, out var validationResults))
                return Results.BadRequest(validationResults);

            Game game = NewGame.ToEntity();
            //game.genre = context.Genres.Find(NewGame.GenreId);

            context.Games.Add(game);
            await context.SaveChangesAsync();

            return Results.CreatedAtRoute("GetGamesById", new{Id = game.Id} , game.ToGameDetails());
        });

        
    return EndPointGroup;
    }
}