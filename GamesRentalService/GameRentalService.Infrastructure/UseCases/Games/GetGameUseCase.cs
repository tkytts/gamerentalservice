using AutoMapper;
using GameRentalService.Infrastructure.Models;
using GameRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace GameRentalService.Infrastructure.UseCases.Games
{
    public class GetGameUseCase : IGetGameUseCase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public GetGameUseCase(
            IGameRepository gameRepository,
            IRentalRepository rentalRepository,
            IMapper mapper)
        {
            _gameRepository = gameRepository;
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<GameViewModel> Execute(int id)
        {
            var game = await _gameRepository.GetAsync(id);
            var gameViewModel = _mapper.Map<GameViewModel>(game);

            if (game != null)
                gameViewModel.RentingFriendId = (await _rentalRepository.GetFriendRentingGame(id))?.Id;

            return gameViewModel;
        }
    }
}
