using Api.Requests;
using AutoMapper;
using Domain.Entities;

namespace Api.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Parking, UpsertParkingRequest>().ReverseMap()
                .AfterMap((p, u) => u.Address.Street = p.Street)
                .AfterMap((p, u) => u.Address.Number = p.Number)
                .AfterMap((p, u) => u.Address.Observation = p.Observation)
                .AfterMap((p, u) => u.Address.Latitude = p.Latitude)
                .AfterMap((p, u) => u.Address.Longitude = p.Longitude);
        }
    }
}
