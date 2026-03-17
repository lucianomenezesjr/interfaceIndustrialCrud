using Microsoft.AspNetCore.Mvc;
using UserCrudApi.DTOs;
using UserCrudApi.Services.Interfaces;

namespace UserCrudApi.Controllers
{
    [ApiController]
    [Route("api/devices/{deviceId:guid}/[controller]")]
    public class ActuatorsController : ControllerBase
    {
        private readonly IActuatorService _service;

        public ActuatorsController(IActuatorService service)
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
        public async Task<IActionResult> Create(Guid deviceId, [FromBody] CreateActuatorDto dto)
        {
            var created = await _service.CreateAsync(deviceId, dto);
            return CreatedAtAction(nameof(GetByDevice), new { deviceId = deviceId }, created);
        }
    }
}
