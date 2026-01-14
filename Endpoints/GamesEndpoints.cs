using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.API.Entities;
using GameStore.API.Repositories;
using Microsoft.Extensions.FileSystemGlobbing;

namespace GameStore.API.Endpoints
{
    public static class GamesEndpoints
    {

        const string GetGameEndpointName = "GetGameById";

        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {
            InMemGamesRepository repository = new();
            var group = routes.MapGroup("/games").WithParameterValidation();

            routes.MapGet("/", () => "Welcome to the Game Store API!");

            // API endpoint to get the list of games
            group.MapGet("/", () => repository.GetAll());

            // API endpoint to get a specific game by ID

            group.MapGet("/{id}", (int id) =>
            {
                Game? game = repository.Get(id);
                return game is not null ? Results.Ok(game) : Results.NotFound();
            }).WithName(GetGameEndpointName);


            group.MapPost("/", (Game game) =>
            {
                repository.Create(game);
                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            });

            group.MapPut("/{id}", (int id, Game updatedGame) =>
            {
                Game? existingGame = repository.Get(id);
                if (existingGame is null)
                {
                    return Results.NotFound();
                }
                existingGame.Name = updatedGame.Name;
                existingGame.Genre = updatedGame.Genre;
                existingGame.Price = updatedGame.Price;
                existingGame.ReleaseDate = updatedGame.ReleaseDate;
                existingGame.ImageUri = updatedGame.ImageUri;

                repository.Update(existingGame);
                return Results.NoContent();
            });

            group.MapDelete("/{id}", (int id) =>
            {
                Game? existingGame = repository.Get(id);
                if (existingGame is null)
                {
                    repository.Delete(id);
                }
                return Results.NoContent();
            });
            return group;
        }

    }
}
