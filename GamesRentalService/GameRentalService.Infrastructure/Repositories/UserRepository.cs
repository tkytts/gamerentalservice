using GameRentalService.Infrastructure.Contexts;
using GamesRentalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetUser(string username, string password)
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin",
                    Role = "admin"
                }
            };

            return users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
