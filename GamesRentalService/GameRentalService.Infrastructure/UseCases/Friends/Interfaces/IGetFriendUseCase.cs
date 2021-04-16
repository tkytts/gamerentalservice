using GamesRentalService.Infrastructure.Models;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.UseCases.Friends.Interfaces
{
    public interface IGetFriendUseCase
    {
        Task<FriendViewModel> Execute(int id);
    }
}
