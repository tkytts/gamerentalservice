using GamesRentalService.Domain.Entities;

namespace GamesRentalService.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
