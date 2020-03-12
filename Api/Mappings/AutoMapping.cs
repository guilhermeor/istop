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
                .AfterMap((p, u) => u.SetAddress(p.Street, p.Number, p.Observation, p.Longitude, p.Latitude));
        }
    }
}
