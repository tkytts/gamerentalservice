using GameRentalService.Infrastructure.Models;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.UseCases.Friends.Interfaces
{
    public interface IDeleteFriendUseCase
    {
        Task Execute(int id);
    }
}
