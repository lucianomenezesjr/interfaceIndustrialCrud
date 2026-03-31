using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using interfaceIndustrialApi.DTOs;

namespace interfaceIndustrialApi.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceResponseDto>> GetAllAsync();
        Task<DeviceResponseDto?> GetByIdAsync(Guid id);
        Task<DeviceResponseDto> CreateAsync(CreateDeviceDto dto);
        Task<DeviceResponseDto?> UpdateAsync(Guid id, UpdateDeviceDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
