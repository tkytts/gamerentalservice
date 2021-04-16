using System;

namespace GameRentalService.Domain.Entities
{
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
