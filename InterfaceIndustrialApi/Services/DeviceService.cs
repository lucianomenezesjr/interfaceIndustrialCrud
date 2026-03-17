using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCrudApi.DTOs;
using UserCrudApi.Models;
using UserCrudApi.Repositories.Interfaces;
using UserCrudApi.Services.Interfaces;

namespace UserCrudApi.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _repo;

        public DeviceService(IDeviceRepository repo)
        {
            _repo = repo;
        }

        public async Task<DeviceResponseDto> CreateAsync(CreateDeviceDto dto)
        {
            var now = DateTime.UtcNow;
            var device = new Device
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                SerialNumber = dto.SerialNumber,
                IpAddress = dto.IpAddress,
                Port = dto.Port,
                RequiresAuthorization = dto.RequiresAuthorization,
                Protocol = Enum.TryParse<DeviceProtocol>(dto.Protocol ?? "", true, out var p) ? p : DeviceProtocol.HTTP,
                Status = DeviceStatus.INACTIVE,
                CreatedAt = now,
                UpdatedAt = now
            };

            var created = await _repo.AddAsync(device);
            return ToDto(created);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<DeviceResponseDto>> GetAllAsync()
        {
            var devices = await _repo.GetAllAsync();
            return devices.Select(d => ToDto(d));
        }

        public async Task<DeviceResponseDto?> GetByIdAsync(Guid id)
        {
            var d = await _repo.GetByIdAsync(id);
            return d == null ? null : ToDto(d);
        }

        public async Task<DeviceResponseDto?> UpdateAsync(Guid id, UpdateDeviceDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;
            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.SerialNumber = dto.SerialNumber;
            existing.IpAddress = dto.IpAddress;
            existing.Port = dto.Port;
            existing.RequiresAuthorization = dto.RequiresAuthorization;
            if (!string.IsNullOrEmpty(dto.Protocol) && Enum.TryParse<DeviceProtocol>(dto.Protocol, true, out var p)) existing.Protocol = p;
            if (!string.IsNullOrEmpty(dto.Status) && Enum.TryParse<DeviceStatus>(dto.Status, true, out var s)) existing.Status = s;
            existing.UpdatedAt = DateTime.UtcNow;
            var updated = await _repo.UpdateAsync(existing);
            return updated == null ? null : ToDto(updated);
        }

        private static DeviceResponseDto ToDto(Device d)
        {
            return new DeviceResponseDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                SerialNumber = d.SerialNumber,
                Protocol = d.Protocol.ToString(),
                IpAddress = d.IpAddress,
                Port = d.Port,
                Status = d.Status.ToString(),
                RequiresAuthorization = d.RequiresAuthorization,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            };
        }
    }
}
