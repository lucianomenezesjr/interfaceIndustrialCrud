using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using interfaceIndustrialApi.DTOs;
using interfaceIndustrialApi.Models;
using interfaceIndustrialApi.Repositories.Interfaces;
using interfaceIndustrialApi.Services.Interfaces;

namespace interfaceIndustrialApi.Services
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _repo;

        public SensorService(ISensorRepository repo)
        {
            _repo = repo;
        }

        public async Task<SensorResponseDto> CreateAsync(Guid deviceId, CreateSensorDto dto)
        {
            var sensor = new Sensor
            {
                Id = Guid.NewGuid(),
                DeviceId = deviceId,
                Name = dto.Name,
                Type = Enum.TryParse<SensorType>(dto.Type ?? "", true, out var t) ? t : SensorType.Other,
                Unit = dto.Unit,
                MinValue = dto.MinValue,
                MaxValue = dto.MaxValue,
                LastUpdate = null
            };
            var created = await _repo.AddAsync(sensor);
            return ToDto(created);
        }

        public async Task<IEnumerable<SensorResponseDto>> GetByDeviceAsync(Guid deviceId)
        {
            var items = await _repo.GetByDeviceAsync(deviceId);
            return items.Select(s => ToDto(s));
        }

        private static SensorResponseDto ToDto(Sensor s)
        {
            return new SensorResponseDto
            {
                Id = s.Id,
                DeviceId = s.DeviceId,
                Name = s.Name,
                Type = s.Type.ToString(),
                Unit = s.Unit,
                CurrentValue = s.CurrentValue,
                MinValue = s.MinValue,
                MaxValue = s.MaxValue,
                LastUpdate = s.LastUpdate
            };
        }
    }
}
