using GamesRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.UseCases.Friends.Interfaces;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.UseCases.Friends
{
    public class DeleteFriendUseCase : IDeleteFriendUseCase
    {
        private readonly IFriendRepository _friendRepository;

        public DeleteFriendUseCase(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public async Task Execute(int id)
        {
            await _friendRepository.DeleteAsync(id);
        }
    }
}
