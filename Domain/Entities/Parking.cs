using Domain.ValueObjects;
using System;

namespace Domain.Entities
{
    public class Parking
    {
        protected Parking()
        {

        }
        public Parking(Guid id, string name, Address address, int spaces, int available = 0, string description = "",
            DateTime opening = default, DateTime closing = default) : this(id, name, spaces, available, description, opening, closing)
        {
            Address = address;
        }

        private Parking(Guid id, string name, int spaces, int available = 0, string description = "", 
            DateTime opening = default, DateTime closing = default)
        {
            Id = id;
            Name = name;
            Description = description;
            Spaces = spaces;
            AvailableSpaces = available;
            OpeningHour = opening;
            ClosingHour = closing;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public int Spaces { get; set; }
        public int AvailableSpaces { get; set; }
        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }
    }
}
