using GameRentalService.Domain.Entities;
using GamesRentalService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameRentalService.Infrastructure.Contexts
{
    public class GameRentalsContext : DbContext
    {
        public GameRentalsContext(DbContextOptions<GameRentalsContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().HasKey(r => new { r.GameId, r.FriendId });
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
