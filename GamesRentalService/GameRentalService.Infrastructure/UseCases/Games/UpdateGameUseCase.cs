using AutoMapper;
using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Models;
using GameRentalService.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace GameRentalService.Infrastructure.UseCases.Games
{
    public class UpdateGameUseCase : IUpdateGameUseCase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public UpdateGameUseCase(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task Execute(GameViewModel gameViewModel)
        {
            var game = _mapper.Map<Game>(gameViewModel);
            await _gameRepository.UpdateAsync(game);
        }
    }
}
