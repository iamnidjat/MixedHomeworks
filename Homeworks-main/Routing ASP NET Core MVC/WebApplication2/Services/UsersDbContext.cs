using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[10] { new User()
            {
                Id = 1,
                FirstName = "Kimberli",
                LastName = "Koenraad",
                Mail = "kkoenraad0@google.nl",
                Gender = "Genderqueer"
            }, new User()
            {
                Id = 2,
                FirstName = "Hillyer",
                LastName = "Leads",
                Mail = "hleads1@vk.com",
                Gender = "Male"
            }, new User()
            {
                Id = 3,
                FirstName = "Yorke",
                LastName = "Craig",
                Mail = "ycraig4@un.org",
                Gender = "Male"
            }, new User()
            {
                Id = 4,
                FirstName = "Agretha",
                LastName = "Till",
                Mail = "atill2@wunderground.com",
                Gender = "Female"
            }, new User()
            {
                Id = 5,
                FirstName = "Emmit",
                LastName = "Filipic",
                Mail = "efilipic3@craigslist.org",
                Gender = "Agender"
            }, new User()
            {
                Id = 6,
                FirstName = "Galvan",
                LastName = "Bottoner",
                Mail = "gbottoner5@un.org",
                Gender = "Polygender"
            }, new User()
            {
                Id = 7,
                FirstName = "Babs",
                LastName = "Bailie",
                Mail = "bbailie6@plala.or.jp",
                Gender = "Female"
            }, new User()
            {
                Id = 8,
                FirstName = "Celka",
                LastName = "Karet",
                Mail = "ckaret7@reference.coml",
                Gender = "Female"
            }, new User()
            {
                Id = 9,
                FirstName = "Odette",
                LastName = "McGonagle",
                Mail = "omcgonagle8@thetimes.co.uk",
                Gender = "Female"
            }, new User()
            {
                Id = 10,
                FirstName = "Loria",
                LastName = "Freeland",
                Mail = "lfreeland9@businessweek.com",
                Gender = "Female"
            }});
        }
    }
}
