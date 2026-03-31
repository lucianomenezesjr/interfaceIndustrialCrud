using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using interfaceIndustrialApi.Data;
using interfaceIndustrialApi.Models;
using interfaceIndustrialApi.Repositories.Interfaces;

namespace interfaceIndustrialApi.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _context;

        public DeviceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Device> AddAsync(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _context.Devices.FindAsync(id);
            if (existing == null) return false;
            _context.Devices.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task<Device?> GetByIdAsync(Guid id)
        {
            return await _context.Devices.Include(d => d.Sensors).Include(d => d.Actuators).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Device?> UpdateAsync(Device device)
        {
            var existing = await _context.Devices.FindAsync(device.Id);
            if (existing == null) return null;
            existing.Name = device.Name;
            existing.Description = device.Description;
            existing.SerialNumber = device.SerialNumber;
            existing.Protocol = device.Protocol;
            existing.IpAddress = device.IpAddress;
            existing.Port = device.Port;
            existing.RequiresAuthorization = device.RequiresAuthorization;
            existing.UpdatedAt = DateTime.UtcNow;
            existing.Status = device.Status;
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
