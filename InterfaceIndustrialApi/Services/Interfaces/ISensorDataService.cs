using System;
using System.Threading.Tasks;
using interfaceIndustrialApi.DTOs;

namespace interfaceIndustrialApi.Services.Interfaces
{
    public interface ISensorDataService
    {
        Task<SensorDataResponseDto> AddDataAsync(Guid sensorId, CreateSensorDataDto dto);
        Task<PagedResult<SensorDataResponseDto>> GetHistoryAsync(Guid sensorId, int page, int pageSize);
    }
}
