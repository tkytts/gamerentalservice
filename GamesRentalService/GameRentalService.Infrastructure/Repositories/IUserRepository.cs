using GamesRentalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
    }
}
