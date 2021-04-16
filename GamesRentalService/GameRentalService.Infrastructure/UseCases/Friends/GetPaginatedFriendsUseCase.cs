using AutoMapper;
using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.UseCases.Friends.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.UseCases.Friends
{
    public class GetPaginatedFriendsUseCase : IGetPaginatedFriendsUseCase
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public GetPaginatedFriendsUseCase(IFriendRepository friendRepository, IRentalRepository rentalRepository, IMapper mapper)
        {
            _friendRepository = friendRepository;
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<FriendViewModel>> Execute(PaginationParameters paginationParameters)
        {
            var friends = _friendRepository.GetAll();
            var rowCount = friends.Count();
            var result = friends.OrderBy(g => g.Name)
                        .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                        .Take(paginationParameters.PageSize)
                        .ToList();

            var viewModels = _mapper.Map<List<Friend>, List<FriendViewModel>>(result);
            var rentedGames = await _rentalRepository.GetRentalsByFriends(viewModels.Select(x => x.Id));

            foreach (var viewModel in viewModels)
                viewModel.RentedGamesIds = rentedGames
                                            .Where(x => x.FriendId == viewModel.Id)
                                            .Select(x => x.GameId)
                                            .ToList();

            return new PagedResult<FriendViewModel>
            {
                Results = viewModels,
                CurrentPage = paginationParameters.PageNumber,
                PageCount = (int)Math.Ceiling((double)rowCount / paginationParameters.PageSize),
                PageSize = paginationParameters.PageSize,
                RowCount = rowCount
            };
        }
    }
}
