using Microsoft.AspNetCore.Mvc;
using interfaceIndustrialApi.DTOs;
using interfaceIndustrialApi.Services.Interfaces;

namespace interfaceIndustrialApi.Controllers
{
    [ApiController]
    [Route("api/sensors/{sensorId:guid}/[controller]")]
    public class SensorDataController : ControllerBase
    {
        private readonly ISensorDataService _service;

        public SensorDataController(ISensorDataService service)
        {
            _service = service;
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory(Guid sensorId, [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            var result = await _service.GetHistoryAsync(sensorId, page, pageSize);
            return Ok(result);
        }

        [HttpPost("data")]
        public async Task<IActionResult> AddData(Guid sensorId, [FromBody] CreateSensorDataDto dto)
        {
            var created = await _service.AddDataAsync(sensorId, dto);
            return Ok(created);
        }
    }
}
