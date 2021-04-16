using AutoMapper;
using GameRentalService.Domain.Entities;
using GamesRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.UseCases.Friends.Interfaces;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.UseCases.Friends
{
    public class CreateFriendUseCase : ICreateFriendUseCase
    {
        private readonly IMapper _mapper;
        private readonly IFriendRepository _friendRepository;

        public CreateFriendUseCase(
            IMapper mapper,
            IFriendRepository friendRepository)
        {
            _mapper = mapper;
            _friendRepository = friendRepository;
        }

        public async Task<FriendViewModel> ExecuteAsync(FriendViewModel friendViewModel)
        {
            var friend = _mapper.Map<Friend>(friendViewModel);
            var result = await _friendRepository.CreateAsync(friend);

            return _mapper.Map<FriendViewModel>(result);
        }
    }
}
