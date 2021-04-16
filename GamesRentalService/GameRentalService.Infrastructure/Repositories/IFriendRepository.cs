using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.Repositories
{
    public interface IFriendRepository
    {
        Task<Friend> CreateAsync(Friend friend);
        Task UpdateAsync(Friend friend);
        IQueryable<Friend> GetAll();
        Task<Friend> GetAsync(int id);
        Task DeleteAsync(int id);
    }
}
