using GameRentalService.Infrastructure.Models;
using GameRentalService.Infrastructure.Repositories;
using GameRentalService.Infrastructure.UseCases.Games.Interfaces;
using System.Threading.Tasks;

namespace GameRentalService.Infrastructure.UseCases.Games
{
    public class DeleteGameUseCase : IDeleteGameUseCase
    {
        private readonly IGameRepository _gameRepository;

        public DeleteGameUseCase(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task Execute(int id)
        {
            await _gameRepository.DeleteAsync(id);
        }
    }
}
