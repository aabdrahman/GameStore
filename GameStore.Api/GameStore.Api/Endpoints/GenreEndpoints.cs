using System;
using System.ComponentModel.DataAnnotations;
using GameStore.Api.Data;
using GameStore.Api.DataTransferObjects;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GenreEndpoints
{

    static bool IsValid<T>(T obj, out ICollection<ValidationResult> results) where T : class
    {
        ValidationContext validationContext = new ValidationContext(obj);
        results = new List<ValidationResult>();

        return Validator.TryValidateObject(obj, validationContext, results);
    }


    public static RouteGroupBuilder RunGenreEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("GetGenre").WithParameterValidation();

        group.MapGet("/", async (GameStoreContext context) =>

                await context.Genres.Select(g => g.ToDTO()).AsNoTracking().ToListAsync()
        );

        group.MapPost("/", async (CreateGenreDTO NewGenre, GameStoreContext context) =>
        {
            
            var genre = NewGenre.ToEntity();

            context.Genres.Add(genre);

            await context.SaveChangesAsync();

            return Results.Ok(genre.ToDTO());
        });

        return group;
    }

}
