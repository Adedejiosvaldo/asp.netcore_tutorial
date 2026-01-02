using GameStore.API.Entities;
const string GetGameEndpointName = "GetGameById";


List<Game> games = new()
{new Game
    {
        Id = 1,
        Name = "The Witcher 3: Wild Hunt",
        Genre = "RPG",
        Price = 39.99M,
        ReleaseDate = new DateTime(2015, 5, 19),
        ImageUri = "https://placehold.co/600x400/png"
    },
    new Game
    {
        Id = 2,
        Name = "Cyberpunk 2077",
        Genre = "Action RPG",
        Price = 59.99M,
        ReleaseDate = new DateTime(2020, 12, 10),
        ImageUri = "https://placehold.co/600x400/png"
    },
    new Game
    {
        Id = 3,
        Name = "God of War",
        Genre = "Action Adventure",
        Price = 49.99M,
        ReleaseDate = new DateTime(2018, 4, 20),
        ImageUri = "https://placehold.co/600x400/png"
    },

};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var group = app.MapGroup("/games");

app.MapGet("/", () => "Welcome to the Game Store API!");
// API endpoint to get the list of games
group.MapGet("/", () => games);

group.MapGet("/{id}",(int id)=>{
    Game? game = games.Find(game=>game.Id==id);
    if (game is null)
    {
return Results.NotFound();
    }
    return Results.Ok(game);
}).WithName(GetGameEndpointName);


group.MapPost("/",(Game game) =>
{
    game.Id = games.Count+1;
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName,new { id = game.Id}, game );
});

group.MapPut("/{id}",(int id, Game updatedGame) =>
{
    Game? existingGame = games.Find(game=>game.Id==id);
    if (existingGame is null)
    {
        return Results.NotFound();
    }
    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUri = updatedGame.ImageUri;
    return Results.NoContent();
});

group.MapDelete("/{id}",(int id) =>
{
    Game? existingGame = games.Find(game=>game.Id==id);
    if (existingGame is not null)
    {
    games.Remove(existingGame);
    }
    return Results.NoContent();
});


app.Run();
