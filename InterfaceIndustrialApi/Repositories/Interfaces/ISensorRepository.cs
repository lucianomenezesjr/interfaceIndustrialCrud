using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using interfaceIndustrialApi.Models;

namespace interfaceIndustrialApi.Repositories.Interfaces
{
    public interface ISensorRepository
    {
        Task<IEnumerable<Sensor>> GetByDeviceAsync(Guid deviceId);
        Task<Sensor> AddAsync(Sensor sensor);
        Task<Sensor?> GetByIdAsync(Guid id);
    }
}
