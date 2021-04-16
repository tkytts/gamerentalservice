using GameRentalService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GamesRentalService.Infrastructure.Models
{
    public class FriendViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("birth_date")]
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("rented_games")]
        public List<int> RentedGamesIds { get; set; }
    }
}
