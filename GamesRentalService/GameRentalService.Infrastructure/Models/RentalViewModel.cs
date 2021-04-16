using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.Models
{
    public class RentalViewModel
    {
        [JsonPropertyName("game_id")]
        public int GameId { get; set; }

        [JsonPropertyName("friend_id")]
        public int FriendId { get; set; }

        [JsonPropertyName("rental_date")]
        public DateTime RentalDate { get; set; }
    }
}
