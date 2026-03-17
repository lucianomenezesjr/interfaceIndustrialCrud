using Microsoft.AspNetCore.Mvc;
using UserCrudApi.DTOs;
using UserCrudApi.Services.Interfaces;

namespace UserCrudApi.Controllers
{
    [ApiController]
    [Route("api/devices/{deviceId:guid}/[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorService _service;

        public SensorsController(ISensorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetByDevice(Guid deviceId)
        {
            var items = await _service.GetByDeviceAsync(deviceId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid deviceId, [FromBody] CreateSensorDto dto)
        {
            var created = await _service.CreateAsync(deviceId, dto);
            return CreatedAtAction(nameof(GetByDevice), new { deviceId = deviceId }, created);
        }
    }
}
