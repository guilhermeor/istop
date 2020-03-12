using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ParkingDbContext _context;
        public ParkingRepository(ParkingDbContext parkingDbContext) => _context = parkingDbContext;

        public void Delete(Parking parking) => _context.Remove(parking);

        public async Task<IEnumerable<Parking>> Get() => await _context.Parkings.ToListAsync();

        public async Task<Parking> GetById(Guid id) =>
            await _context.Parkings.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Parking>> Get(double originLat, double originLong, float radius) 
            => await _context.Parkings.Where(_ => Math.Sqrt(Math.Pow(_.Address.Latitude - originLat,2) + Math.Pow(_.Address.Longitude - originLong,2)) <= radius).ToListAsync();
        public async Task Add(Parking parking) => await _context.AddAsync(parking);
    }
}
