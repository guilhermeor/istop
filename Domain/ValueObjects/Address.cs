using Microsoft.EntityFrameworkCore;

namespace Domain.ValueObjects
{
    [Owned]
    public class Address
    {
        public Address() { }
        public Address(string street, string number, string observation = "")
        {
            Street = street;
            Number = number;
            Observation = observation;
        }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Observation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
