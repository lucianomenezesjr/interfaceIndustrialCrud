using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using interfaceIndustrialApi.Models;

namespace interfaceIndustrialApi.Repositories.Interfaces
{
    public interface ISensorDataRepository
    {
        Task AddAsync(SensorData data);
        Task<(IEnumerable<SensorData> Items, long Total)> GetHistoryAsync(Guid sensorId, int page, int pageSize);
    }
}
