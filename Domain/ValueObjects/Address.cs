using Microsoft.EntityFrameworkCore;

namespace Domain.ValueObjects
{
    [Owned]
    public class Address
    {
        public Address() { }
        public Address(string street, string number, string observation = "", double longitude=0, double latitude = 0)
        {
            Street = street;
            Number = number;
            Observation = observation;
            Latitude = latitude;
            Longitude = longitude;
        }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Observation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
