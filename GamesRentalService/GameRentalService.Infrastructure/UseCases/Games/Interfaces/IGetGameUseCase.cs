using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Models;
using System.Threading.Tasks;

namespace GameRentalService.Infrastructure.UseCases.Games
{
    public interface IGetGameUseCase
    {
        Task<GameViewModel> Execute(int id);
    }
}
