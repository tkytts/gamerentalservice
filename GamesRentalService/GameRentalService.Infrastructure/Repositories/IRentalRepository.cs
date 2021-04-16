using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.Repositories
{
    public interface IRentalRepository
    {
        Task<bool> GameIsRented(int gameId);
        Task<List<Rental>> GetRentalsByFriends(IEnumerable<int> friendIds);
        Task<Result<Rental>> CreateRental(Rental rental);
        Task DeleteAsync(int id);
        Task<List<Game>> GetGamesRentedByFriend(int friendId);
        Task<Friend> GetFriendRentingGame(int gameId);
        Task<List<Rental>> GetRentalsByGames(IEnumerable<int> gameIds);
    }
}
