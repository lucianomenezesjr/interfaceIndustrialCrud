using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using interfaceIndustrialApi.Models;

namespace interfaceIndustrialApi.Repositories.Interfaces
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllAsync();
        Task<Device?> GetByIdAsync(Guid id);
        Task<Device> AddAsync(Device device);
        Task<Device?> UpdateAsync(Device device);
        Task<bool> DeleteAsync(Guid id);
    }
}
