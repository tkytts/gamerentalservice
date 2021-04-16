using GameRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Models;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.UseCases.Rentals.Interfaces
{
    public interface IRentGameUseCase
    {
        Task<Result> Execute(RentalViewModel viewModel);
    }
}
