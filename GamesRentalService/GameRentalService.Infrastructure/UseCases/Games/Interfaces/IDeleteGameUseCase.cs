using GameRentalService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameRentalService.Infrastructure.UseCases.Games.Interfaces
{
    public interface IDeleteGameUseCase
    {
        Task Execute(int id);
    }
}
