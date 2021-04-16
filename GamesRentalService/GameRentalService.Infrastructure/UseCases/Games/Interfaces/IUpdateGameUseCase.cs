using GameRentalService.Infrastructure.Models;
using System.Threading.Tasks;

namespace GameRentalService.Infrastructure.UseCases.Games
{
    public interface IUpdateGameUseCase
    {
        Task Execute(GameViewModel gameViewModel);
    }
}
