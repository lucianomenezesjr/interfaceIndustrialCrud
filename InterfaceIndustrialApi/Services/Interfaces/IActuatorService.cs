using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserCrudApi.DTOs;

namespace UserCrudApi.Services.Interfaces
{
    public interface IActuatorService
    {
        Task<IEnumerable<ActuatorResponseDto>> GetByDeviceAsync(Guid deviceId);
        Task<ActuatorResponseDto> CreateAsync(Guid deviceId, CreateActuatorDto dto);
        Task<ActuatorResponseDto?> UpdateAsync(Guid id, UpdateActuatorDto dto);
    }
}
