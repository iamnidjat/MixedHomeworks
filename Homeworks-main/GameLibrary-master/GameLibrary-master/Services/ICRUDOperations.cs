using GameLibrary.Entities;
using GameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Services
{
    public interface ICRUDOperations
    {
        ObservableCollection<Game> ShowGames(ObservableCollection<Game> games);
        Task UpdateGame(string oldTitle, Game game);
        Task AddGame(Game game);
        Task DeleteGame(string title);
        ObservableCollection<Game> SearchGame(string title, ObservableCollection<Game> games);
        Task AddingCharsForGames(GameCharacteristics gameCharacteristics);
        ObservableCollection<GameCharacteristics> ShowCharsForGames(ObservableCollection<GameCharacteristics> gamesChars, int id);
    }
}
