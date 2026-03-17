using System;
using System.Threading.Tasks;
using UserCrudApi.DTOs;

namespace UserCrudApi.Services.Interfaces
{
    public interface ISensorDataService
    {
        Task<SensorDataResponseDto> AddDataAsync(Guid sensorId, CreateSensorDataDto dto);
        Task<PagedResult<SensorDataResponseDto>> GetHistoryAsync(Guid sensorId, int page, int pageSize);
    }
}
