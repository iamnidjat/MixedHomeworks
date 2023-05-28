using Cinema.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace Cinema.Services
{
    public class SessionService : ISessionService
    {
        private readonly MyDbContext _dbContext;

        public SessionService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddItemAsync(SessionItem item)
        {
            await _dbContext.Sessions.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditItemAsync(SessionItem item)
        {
            var data = _dbContext.Sessions.Where(x => x.Id == item.Id).FirstOrDefault();

            if (data != null)
            {
                data.Title = item.Title;
                data.ShowDate = item.ShowDate;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveItemAsync(int index)
        {
            var result = await GetProductByIdAsync(index);

            if (result != null)
            {
                _dbContext.Sessions.Remove(result);

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<SessionItem?> GetProductByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _dbContext.Sessions.SingleOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<SessionItem> GetItems()
        {
            //foreach (var item in _dbContext.Sessions)
            //{
            //    yield return item;
            //}
            return _dbContext.Sessions.Include(d => d.Cinema).ToList();
        }

        public IEnumerable<CinemaItem> GetCinemas()
        {
            return _dbContext.Cinemas.ToList();
        }

        public SessionItem GetSession(int id)
        {
            return _dbContext.Sessions.Where(x => x.Id == id).FirstOrDefault();
        }

        public string GetCinemaTitle(int id)
        {
            return _dbContext.Cinemas.Where(x => x.Id == id).FirstOrDefault().CinemaTitle;
        }
    }
}
