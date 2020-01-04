using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task Add(Parking parking) => await _context.AddAsync(parking);
    }
}
