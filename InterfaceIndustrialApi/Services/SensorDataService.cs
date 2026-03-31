using System;
using System.Linq;
using System.Threading.Tasks;
using interfaceIndustrialApi.DTOs;
using interfaceIndustrialApi.Models;
using interfaceIndustrialApi.Repositories.Interfaces;
using interfaceIndustrialApi.Services.Interfaces;

namespace interfaceIndustrialApi.Services
{
    public class SensorDataService : ISensorDataService
    {
        private readonly ISensorDataRepository _repo;

        public SensorDataService(ISensorDataRepository repo)
        {
            _repo = repo;
        }

        public async Task<SensorDataResponseDto> AddDataAsync(Guid sensorId, CreateSensorDataDto dto)
        {
            var data = new SensorData
            {
                Id = Guid.NewGuid(),
                SensorId = sensorId,
                DeviceId = Guid.Empty, // DeviceId can be filled by caller/service if needed
                Value = dto.Value,
                Timestamp = DateTime.UtcNow
            };
            await _repo.AddAsync(data);
            return new SensorDataResponseDto
            {
                Id = data.Id,
                SensorId = data.SensorId,
                DeviceId = data.DeviceId,
                Value = data.Value,
                Timestamp = data.Timestamp
            };
        }

        public async Task<PagedResult<SensorDataResponseDto>> GetHistoryAsync(Guid sensorId, int page, int pageSize)
        {
            var result = await _repo.GetHistoryAsync(sensorId, page, pageSize);
            var items = result.Items;
            var total = result.Total;
            var dtoItems = items.Select(i => new SensorDataResponseDto
            {
                Id = i.Id,
                SensorId = i.SensorId,
                DeviceId = i.DeviceId,
                Value = i.Value,
                Timestamp = i.Timestamp
            }).ToList();

            return new PagedResult<SensorDataResponseDto>
            {
                Items = dtoItems,
                Page = page,
                PageSize = pageSize,
                Total = total
            };
        }
    }
}
