using AutoMapper;
using GameRentalService.Domain.Entities;
using GamesRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.UseCases.Friends.Interfaces;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.UseCases.Friends
{
    public class UpdateFriendUseCase : IUpdateFriendUseCase
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;

        public UpdateFriendUseCase(IFriendRepository friendRepository, IMapper mapper)
        {
            _friendRepository = friendRepository;
            _mapper = mapper;
        }

        public async Task Execute(FriendViewModel friendViewModel)
        {
            var friend = _mapper.Map<Friend>(friendViewModel);
            await _friendRepository.UpdateAsync(friend);
        }
    }
}
