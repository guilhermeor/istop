using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IParkingRepository
    {
        Task<Parking> GetById(Guid id);
        Task<IEnumerable<Parking>> Get();
        Task<IEnumerable<Parking>> Get(double originLat, double originLong, float radius);
        Task Add(Parking parking);
        void Delete(Parking parking);
    }
}
