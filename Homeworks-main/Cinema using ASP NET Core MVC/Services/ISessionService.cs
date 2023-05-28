using Cinema.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Services
{
    public interface ISessionService
    {
        Task AddItemAsync(SessionItem item);
        Task EditItemAsync(SessionItem item);
        Task RemoveItemAsync(int index);
        IEnumerable<SessionItem> GetItems();
        IEnumerable<CinemaItem> GetCinemas();
        SessionItem GetSession(int id);
        string GetCinemaTitle(int id);
    }
}
