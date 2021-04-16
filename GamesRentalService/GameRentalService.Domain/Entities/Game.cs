using System;
using System.Text.Json.Serialization;

namespace GameRentalService.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Rented { get; set;  }
    }
}
