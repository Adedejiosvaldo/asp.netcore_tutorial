using GameStore.API.Entities;

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
    }
};


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
