using AutoMapper;
using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.UseCases.Rentals.Interfaces;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.UseCases.Rentals
{
    public class RentGameUseCase : IRentGameUseCase
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public RentGameUseCase(
            IRentalRepository rentalRepository,
            IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<Result> Execute(RentalViewModel viewModel)
        {
            var result = new Result();

            if (await _rentalRepository.GameIsRented(viewModel.GameId))
            {
                result.ErrorMessages.Add(RentalResources.GAME_ALREADY_RENTED);
                return result;
            }

            var rental = _mapper.Map<Rental>(viewModel);
            await _rentalRepository.CreateRental(rental);
            result.Success = true;

            return result;
        }
    }
}
