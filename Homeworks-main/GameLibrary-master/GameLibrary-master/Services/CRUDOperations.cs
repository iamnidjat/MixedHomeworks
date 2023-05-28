using GameLibrary.Entities;
using GameLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace GameLibrary.Services
{
    public class CRUDOperations : ICRUDOperations
    {
        private GameLibraryDbContext context;

        public CRUDOperations()
        {
            context = new GameLibraryDbContext();
        }

        public ObservableCollection<Game> ShowGames(ObservableCollection<Game> games)
        {
            var result = context.Games.ToList();

            foreach (var item in result)
            {
                games.Add(new Game
                {
                    Id = item.Id,
                    Title = item.Title,
                    Category = item.Category,
                    Price = item.Price,
                });
            }

            return games;
        }

        public ObservableCollection<GameCharacteristics> ShowCharsForGames(ObservableCollection<GameCharacteristics> gamesChars, int id)
        {
            var result = context.GamesCharacteristics.Where(x => x.GameId == id + 1);

            foreach (var item in result)
            {
                gamesChars.Add(new GameCharacteristics
                {
                    Id = item.Id,
                    Description = item.Description,
                    Developer = item.Developer,
                    Manufacturer = item.Manufacturer,
                    Raiting = item.Raiting,
                    Comments = item.Comments,
                    IssueDate = item.IssueDate,
                    Tags = item.Tags,
                    Publisher = item.Publisher,
                    GameId = item.GameId
                });
            }

            return gamesChars;
        }

        public Task AddingCharsForGames(GameCharacteristics gameCharacteristics)
        {
            return Task.Run(() =>
            {
                if (gameCharacteristics != null)
                {
                    context.GamesCharacteristics.Add(gameCharacteristics);
                    context.SaveChanges();
                }
            });
        }

        public Task UpdateGame(string oldTitle, Game game)
        {
            return Task.Run(() =>
            {
                var result = context.Games.FirstOrDefault(x => x.Title == oldTitle);

                if (result == null)
                {
                    return;
                }

                result.Title = game.Title;
                result.Category = game.Category;
                result.Price = game.Price;

                context.SaveChanges();
            });
        }

        public Task AddGame(Game game)
        {
            return Task.Run(() =>
            {
                if (game != null)
                {
                    context.Games.Add(game);
                    context.SaveChanges();
                }
            });
        }

        public Task DeleteGame(string title)
        {
            return Task.Run(() =>
            {
                var result = context.Games.FirstOrDefault(x => x.Title == title);

                if (result == null)
                {
                    return;
                }

                context.Games.Remove(result);
                context.SaveChanges();
            });
        }

        public ObservableCollection<Game> SearchGame(string title, ObservableCollection<Game> games)
        {
            var result = context.Games.Where(x => x.Title == title);

            if (result == null)
            {
                return null;
            }


            foreach(var item in result)
            {
                games.Add(new Game
                {
                    Title = item.Title,
                    Category = item.Category,
                    Price = item.Price
                });
            }

            return games;
        }
    }
}
