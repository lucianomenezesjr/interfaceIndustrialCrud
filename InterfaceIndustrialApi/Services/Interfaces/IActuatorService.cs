using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using interfaceIndustrialApi.DTOs;

namespace interfaceIndustrialApi.Services.Interfaces
{
    public interface IActuatorService
    {
        Task<IEnumerable<ActuatorResponseDto>> GetByDeviceAsync(Guid deviceId);
        Task<ActuatorResponseDto> CreateAsync(Guid deviceId, CreateActuatorDto dto);
        Task<ActuatorResponseDto?> UpdateAsync(Guid id, UpdateActuatorDto dto);
    }
}
