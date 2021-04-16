using System;
using System.Collections.Generic;
using System.Text;

namespace GameRentalService.Domain.Entities
{
    public class Rental
    {
        public int GameId { get; set; }
        public int FriendId { get; set; }
        public DateTime RentalDate { get; set; }
    }
}
