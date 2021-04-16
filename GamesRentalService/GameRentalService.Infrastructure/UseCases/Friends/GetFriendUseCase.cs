using AutoMapper;
using GamesRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.UseCases.Friends.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.UseCases.Friends
{
    public class GetFriendUseCase : IGetFriendUseCase
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public GetFriendUseCase(IFriendRepository friendRepository, IRentalRepository rentalRepository, IMapper mapper)
        {
            _friendRepository = friendRepository;
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<FriendViewModel> Execute(int id)
        {
            var friend = await _friendRepository.GetAsync(id);
            var friendViewModel = _mapper.Map<FriendViewModel>(friend);

            if (friend != null)
                friendViewModel.RentedGamesIds = (await _rentalRepository.GetGamesRentedByFriend(id)).Select(x => x.Id).ToList();

            return friendViewModel;
        }
    }
}
