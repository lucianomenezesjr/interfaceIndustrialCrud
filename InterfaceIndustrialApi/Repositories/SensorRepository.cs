using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using interfaceIndustrialApi.Data;
using interfaceIndustrialApi.Models;
using interfaceIndustrialApi.Repositories.Interfaces;

namespace interfaceIndustrialApi.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly AppDbContext _context;

        public SensorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Sensor> AddAsync(Sensor sensor)
        {
            _context.Sensors.Add(sensor);
            await _context.SaveChangesAsync();
            return sensor;
        }

        public async Task<Sensor?> GetByIdAsync(Guid id)
        {
            return await _context.Sensors.FindAsync(id);
        }

        public async Task<IEnumerable<Sensor>> GetByDeviceAsync(Guid deviceId)
        {
            return await _context.Sensors.Where(s => s.DeviceId == deviceId).ToListAsync();
        }
    }
}
