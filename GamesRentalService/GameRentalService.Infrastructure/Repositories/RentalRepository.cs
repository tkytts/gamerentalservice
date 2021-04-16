using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Contexts;
using GameRentalService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        public readonly GameRentalsContext _db;
        public RentalRepository(
            GameRentalsContext db)
        {
            _db = db;
        }

        public async Task<bool> GameIsRented(int gameId)
        {
            var rentalExists = await _db.Rentals.Where(x => x.GameId == gameId).AnyAsync();
            return rentalExists;
        }

        public async Task<List<Rental>> GetRentalsByFriends(IEnumerable<int> friendIds)
        {
            var rentals = await _db.Rentals.Where(x => friendIds.Contains(x.FriendId)).ToListAsync();

            return rentals;
        }

        public async Task<Result<Rental>> CreateRental(Rental rental)
        {
            var result = new Result<Rental>();

            _db.Rentals.Add(rental);
            await _db.SaveChangesAsync();

            result.Success = true;
            result.ResultObject = rental;

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var rental = _db.Rentals.Find(id);
            _db.Rentals.Remove(rental);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Game>> GetGamesRentedByFriend(int friendId)
        {
            var rentedGames = from rentals in _db.Rentals
                              join games in _db.Games on rentals.GameId equals games.Id
                              where rentals.FriendId == friendId
                              select games;

            return await rentedGames.ToListAsync();
        }

        public async Task<Friend> GetFriendRentingGame(int gameId)
        {
            var friend = await (from rentals in _db.Rentals
                                join friends in _db.Friends on rentals.FriendId equals friends.Id
                                where rentals.GameId == gameId
                                select friends).SingleOrDefaultAsync();

            return friend;
        }

        public async Task<List<Rental>> GetRentalsByGames(IEnumerable<int> gameIds)
        {
            var rentals = _db.Rentals.Where(x => gameIds.Contains(x.GameId));
         
            return await rentals.ToListAsync();
        }
    }
}