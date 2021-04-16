using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Contexts;
using GameRentalService.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace GameRentalService.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        public readonly GameRentalsContext _db;
        public GameRepository(
            GameRentalsContext db)
        {
            _db = db;
        }

        public IQueryable<Game> GetAll()
        {
            return _db.Games;
        }

        public async Task<Game> GetAsync(int id)
        {
            var game = await _db.Games.FindAsync(id);

            return game;
        }

        public async Task<Game> CreateAsync(Game game)
        {
            _db.Games.Add(game);
            await _db.SaveChangesAsync();

            return game;
        }

        public async Task UpdateAsync(Game game)
        {
            _db.Games.Update(game);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var game = _db.Games.Find(id);
            _db.Games.Remove(game);
            await _db.SaveChangesAsync();
        }
    }
}