using GameLibrary.Entities;
using GameLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameLibrary.Services
{
    public class GameLibraryDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // For EF 6
        //#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        //        public GameLibraryDbContext() : base(ConfigurationManager.ConnectionStrings["GameLibrary"].ConnectionString)
        //#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        //        {

        //        }

#pragma warning disable CS8618
        public GameLibraryDbContext() : base()
#pragma warning restore CS8618
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["GameLibrary"].ConnectionString);
        }

        public Microsoft.EntityFrameworkCore.DbSet<Game> Games { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<GameCharacteristics> GamesCharacteristics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Можете дропнуть бд и заново запустить программу тогда увидите эти значения

            //modelBuilder.Entity<Game>(g =>
            //{
            //    g.HasData(new Game
            //    {
            //        Id = 1,
            //        Title = "Clash of Clans",
            //        Category = "Strategy",
            //        Price = 69
            //    });
            //});


            //modelBuilder.Entity<GameCharacteristics>(g =>
            //{
            //    g.HasData(new GameCharacteristics
            //    {
            //        Id = 1,
            //        Developer = "Supercell",
            //        Description = "Strategy game",
            //        Manufacturer = "Supercell",
            //        Raiting = "50",
            //        Comments = "good game",
            //        Publisher = "Supercell",
            //        Tags = "#clash",
            //        IssueDate = DateTime.Now,
            //        GameId = 1
            //    });
            //});

            modelBuilder.Entity<Game>(g =>
            {  
                g.HasOne(a => a.gameCharacteristics)
                .WithOne(b => b.games)
                .HasForeignKey<GameCharacteristics>(b => b.GameId);
            });

            modelBuilder.Entity<Game>(g =>
            {
                g.Property(p => p.Title).IsRequired();
                g.Property(p => p.Category).IsRequired();
                g.Property(p => p.Price).HasPrecision(3);
            });


            modelBuilder.Entity<GameCharacteristics>(g =>
            {
                g.Property(p => p.Description).IsRequired();
                g.Property(p => p.Developer).IsRequired();
                g.Property(p => p.Manufacturer).IsRequired();
                g.Property(p => p.Raiting).IsRequired();
                g.Property(p => p.Publisher).IsRequired();
                g.Property(p => p.Tags).IsRequired();
                g.Property(p => p.Comments).IsRequired();
                g.Property(p => p.GameId).IsRequired();
            });
        }
    }
}
