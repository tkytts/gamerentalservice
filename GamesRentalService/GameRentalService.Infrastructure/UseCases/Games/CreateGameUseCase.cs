using AutoMapper;
using GameRentalService.Infrastructure.Models;
using GameRentalService.Infrastructure.Repositories;
using System.Threading.Tasks;
using GameRentalService.Domain.Entities;


namespace GameRentalService.Infrastructure.UseCases.Games
{
    public class CreateGameUseCase : ICreateGameUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;

        public CreateGameUseCase(
            IMapper mapper,
            IGameRepository gameRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
        }

        public async Task<GameViewModel> ExecuteAsync(GameViewModel gameViewModel)
        {
            var game = _mapper.Map<Game>(gameViewModel);
            var result = await _gameRepository.CreateAsync(game);

            return _mapper.Map<GameViewModel>(result);
        }
    }
}
