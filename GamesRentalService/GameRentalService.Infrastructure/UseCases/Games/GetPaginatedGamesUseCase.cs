using AutoMapper;
using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Models;
using GameRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRentalService.Infrastructure.UseCases.Games
{
    public class GetPaginatedGamesUseCase : IGetPaginatedGamesUseCase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public GetPaginatedGamesUseCase(IGameRepository gameRepository, IRentalRepository rentalRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GameViewModel>> Execute(PaginationParameters paginationParameters)
        {
            var games = _gameRepository.GetAll();
            var rowCount = games.Count();
            var result = games.OrderBy(g => g.Name)
                        .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                        .Take(paginationParameters.PageSize)
                        .ToList();

            var gamesViewModels = _mapper.Map<List<Game>, List<GameViewModel>>(result);
            var rentals = await _rentalRepository.GetRentalsByGames(gamesViewModels.Select(x => x.Id));

            foreach (var gameViewModel in gamesViewModels)
                gameViewModel.RentingFriendId = rentals.FirstOrDefault(x => x.GameId == gameViewModel.Id)?.FriendId;

            return new PagedResult<GameViewModel>
            {
                Results = gamesViewModels,
                CurrentPage = paginationParameters.PageNumber,
                PageCount = (int)Math.Ceiling((double)rowCount / paginationParameters.PageSize),
                PageSize = paginationParameters.PageSize,
                RowCount = rowCount
            };
        }
    }
}
