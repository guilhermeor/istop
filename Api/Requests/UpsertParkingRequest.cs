using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Requests
{
    public class UpsertParkingRequest : ParkingRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Observation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Spaces { get; set; }
        public int AvailableSpaces { get; set; }
        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }
    }
}
