using GameRentalService.Infrastructure.Models;
using System.Threading.Tasks;

namespace GameRentalService.Infrastructure.UseCases.Games
{
    public interface ICreateGameUseCase
    {
        Task<GameViewModel> ExecuteAsync(GameViewModel gameViewModel);
    }
}
