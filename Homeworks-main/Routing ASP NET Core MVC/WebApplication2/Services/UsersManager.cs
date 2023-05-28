using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IUsersManager
    {
        User? GetUserById(int? id);
    }

    public class UsersManager : IUsersManager
    {
        private readonly UsersDbContext _context;

        public UsersManager(UsersDbContext context)
        {
            _context = context;
        }

        public User? GetUserById(int? id)
        {
            if (id == null || id > _context.Users.Count() || id < 0)
            {
                return null;
            }

            return  _context.Users.SingleOrDefault(x => x.Id == id);
        }
    }
}
