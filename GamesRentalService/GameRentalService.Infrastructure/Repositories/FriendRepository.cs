using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Contexts;
using GameRentalService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        public readonly GameRentalsContext _db;
        public FriendRepository(
            GameRentalsContext db)
        {
            _db = db;
        }

        public async Task<Friend> CreateAsync(Friend friend)
        {
            _db.Friends.Add(friend);
            await _db.SaveChangesAsync();

            return friend;
        }

        public async Task DeleteAsync(int id)
        {
            var friend = _db.Friends.Find(id);
            _db.Friends.Remove(friend);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Friend> GetAll()
        {
            return _db.Friends;
        }

        public async Task<Friend> GetAsync(int id)
        {
            var friend = await _db.Friends.FindAsync(id);

            return friend;
        }

        public async Task UpdateAsync(Friend friend)
        {
            _db.Friends.Update(friend);
            await _db.SaveChangesAsync();
        }
    }
}
