using Cinema.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Cinema.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly MyDbContext _dbContext;

        public CinemaService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddItemAsync(CinemaItem item)
        {
            await _dbContext.Cinemas.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CinemaItem?> GetProductByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _dbContext.Cinemas.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task EditItemAsync(CinemaItem item)
        {
            var data = _dbContext.Cinemas.Where(x => x.Id == item.Id).FirstOrDefault();

            if (data != null)
            {
                data.CinemaTitle = item.CinemaTitle;
                data.Description = item.Description;
                 _dbContext.SaveChanges();
            }
        }

        public async Task RemoveItemAsync(int id)
        {
            var result = await GetProductByIdAsync(id);

            if (result != null)
            {
                _dbContext.Cinemas.Remove(result);

                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<CinemaItem> GetItems()
        {
            foreach (var item in _dbContext.Cinemas)
            {
                yield return item;
            }
        }

        public CinemaItem GetCinema(int id)
        {
            return _dbContext.Cinemas.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
