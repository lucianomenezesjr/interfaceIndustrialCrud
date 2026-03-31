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
    public class ActuatorRepository : IActuatorRepository
    {
        private readonly AppDbContext _context;

        public ActuatorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Actuator> AddAsync(Actuator actuator)
        {
            _context.Actuators.Add(actuator);
            await _context.SaveChangesAsync();
            return actuator;
        }

        public async Task<Actuator?> GetByIdAsync(Guid id)
        {
            return await _context.Actuators.FindAsync(id);
        }

        public async Task<IEnumerable<Actuator>> GetByDeviceAsync(Guid deviceId)
        {
            return await _context.Actuators.Where(a => a.DeviceId == deviceId).ToListAsync();
        }

        public async Task<Actuator?> UpdateAsync(Actuator actuator)
        {
            var existing = await _context.Actuators.FindAsync(actuator.Id);
            if (existing == null) return null;
            existing.Name = actuator.Name;
            existing.Type = actuator.Type;
            existing.CurrentValue = actuator.CurrentValue;
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
