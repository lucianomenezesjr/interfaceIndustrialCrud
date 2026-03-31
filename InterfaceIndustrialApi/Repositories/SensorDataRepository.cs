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
    public class SensorDataRepository : ISensorDataRepository
    {
        private readonly AppDbContext _context;

        public SensorDataRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SensorData data)
        {
            _context.SensorData.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task<(IEnumerable<SensorData> Items, long Total)> GetHistoryAsync(Guid sensorId, int page, int pageSize)
        {
            var query = _context.SensorData.Where(sd => sd.SensorId == sensorId).OrderByDescending(sd => sd.Timestamp);
            var total = await query.LongCountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, total);
        }
    }
}
