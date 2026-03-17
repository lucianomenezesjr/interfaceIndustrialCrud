using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserCrudApi.DTOs;

namespace UserCrudApi.Services.Interfaces
{
    public interface ISensorService
    {
        Task<IEnumerable<SensorResponseDto>> GetByDeviceAsync(Guid deviceId);
        Task<SensorResponseDto> CreateAsync(Guid deviceId, CreateSensorDto dto);
    }
}
