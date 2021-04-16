using GameRentalService.Infrastructure.Models;
using System.Threading.Tasks;

namespace GameRentalService.Infrastructure.UseCases.Games
{
    public interface IGetPaginatedGamesUseCase
    {
        Task<PagedResult<GameViewModel>> Execute(PaginationParameters paginationParameters);
    }
}
