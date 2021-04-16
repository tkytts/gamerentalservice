using System;
using System.Text.Json.Serialization;

namespace GameRentalService.Infrastructure.Models
{
    public class GameViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("renting_friend_id")]

        public int? RentingFriendId { get; set; }
    }
}
