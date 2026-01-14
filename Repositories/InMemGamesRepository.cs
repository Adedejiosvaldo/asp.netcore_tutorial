using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.API.Entities;

namespace GameStore.API.Repositories
{
    public class InMemGamesRepository
    {
        private readonly List<Game> games = new(){new Game {
        Id = 1,
        Name = "The Witcher 3: Wild Hunt",
        Genre = "RPG",
        Price = 39.99M,
        ReleaseDate = new DateTime(2015, 5, 19),
        ImageUri = "https://placehold.co/600x400/png"},
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


        public IEnumerable<Game> GetAll()
        {
            return games;
        }
        public Game? Get(int id)
        {
            return games.Find(game => game.Id == id);
        }


        public void Create(Game game)
        {
            game.Id = games.Count + 1;
            games.Add(game);
        }


        public void Update(Game updatedGame)
        {

            var index = games.FindIndex(game => game.Id == updatedGame.Id);

            games[index] = updatedGame;
        }

        public void Delete(int id)
        {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);
        }
    };

}
