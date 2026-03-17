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
    public class ActuatorService : IActuatorService
    {
        private readonly IActuatorRepository _repo;

        public ActuatorService(IActuatorRepository repo)
        {
            _repo = repo;
        }

        public async Task<ActuatorResponseDto> CreateAsync(Guid deviceId, CreateActuatorDto dto)
        {
            var actuator = new Actuator
            {
                Id = Guid.NewGuid(),
                DeviceId = deviceId,
                Name = dto.Name,
                Type = dto.Type,
                SignalType = Enum.TryParse<SignalType>(dto.SignalType ?? "", true, out var s) ? s : SignalType.Digital,
                MinValue = dto.MinValue,
                MaxValue = dto.MaxValue,
                CurrentValue = null
            };
            var created = await _repo.AddAsync(actuator);
            return ToDto(created);
        }

        public async Task<IEnumerable<ActuatorResponseDto>> GetByDeviceAsync(Guid deviceId)
        {
            var items = await _repo.GetByDeviceAsync(deviceId);
            return items.Select(a => ToDto(a));
        }

        public async Task<ActuatorResponseDto?> UpdateAsync(Guid id, UpdateActuatorDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;
            existing.Name = dto.Name;
            existing.Type = dto.Type;
            if (dto.CurrentValue.HasValue) existing.CurrentValue = dto.CurrentValue.Value;
            var updated = await _repo.UpdateAsync(existing);
            return updated == null ? null : ToDto(updated);
        }

        private static ActuatorResponseDto ToDto(Actuator a)
        {
            return new ActuatorResponseDto
            {
                Id = a.Id,
                DeviceId = a.DeviceId,
                Name = a.Name,
                Type = a.Type,
                SignalType = a.SignalType.ToString(),
                CurrentValue = a.CurrentValue,
                MinValue = a.MinValue,
                MaxValue = a.MaxValue
            };
        }
    }
}
