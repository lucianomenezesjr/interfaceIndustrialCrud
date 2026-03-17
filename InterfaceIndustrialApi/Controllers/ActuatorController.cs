using Microsoft.AspNetCore.Mvc;
using UserCrudApi.DTOs;
using UserCrudApi.Services.Interfaces;

namespace UserCrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActuatorController : ControllerBase
    {
        private readonly IActuatorService _service;

        public ActuatorController(IActuatorService service)
        {
            _service = service;
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateActuatorDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
    }
}
