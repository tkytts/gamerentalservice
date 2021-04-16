using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GameRentalService.Infrastructure.Repositories
{
    public interface IGameRepository
    {
        Task<Game> CreateAsync(Game game);
        Task UpdateAsync(Game game);
        IQueryable<Game> GetAll();
        Task<Game> GetAsync(int id);
        Task DeleteAsync(int id);
    }
}
