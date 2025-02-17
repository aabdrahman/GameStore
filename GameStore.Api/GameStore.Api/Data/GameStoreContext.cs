using System;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>()
                    .HasData(
                        new 
                        {
                            Id = 1,
                            Name = "Racing"
                        },
                        new 
                        {
                            Id = 2,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 3,
                            Name = "First-Person Shooter"
                        }

                    );
    }
}
