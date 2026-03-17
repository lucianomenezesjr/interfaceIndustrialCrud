using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserCrudApi.Models;

namespace UserCrudApi.Repositories.Interfaces
{
    public interface ISensorDataRepository
    {
        Task AddAsync(SensorData data);
        Task<(IEnumerable<SensorData> Items, long Total)> GetHistoryAsync(Guid sensorId, int page, int pageSize);
    }
}
