using GameRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Models;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.UseCases.Friends.Interfaces
{
    public interface IUpdateFriendUseCase
    {
        Task Execute(FriendViewModel friendViewModel);
    }
}
