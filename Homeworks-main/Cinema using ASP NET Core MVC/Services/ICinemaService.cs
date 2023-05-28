using Cinema.Models;

namespace Cinema.Services
{
    public interface ICinemaService
    {
        Task AddItemAsync(CinemaItem item);
        Task EditItemAsync(CinemaItem item);
        Task RemoveItemAsync(int index);
        IEnumerable<CinemaItem> GetItems();
        CinemaItem GetCinema(int id);
    }
}
