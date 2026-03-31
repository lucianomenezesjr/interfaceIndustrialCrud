using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using interfaceIndustrialApi.DTOs;

namespace interfaceIndustrialApi.Services.Interfaces
{
    public interface ISensorService
    {
        Task<IEnumerable<SensorResponseDto>> GetByDeviceAsync(Guid deviceId);
        Task<SensorResponseDto> CreateAsync(Guid deviceId, CreateSensorDto dto);
    }
}
