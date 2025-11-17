using Microsoft.AspNetCore.Mvc;
using Pausinha.Api.DTOs;
using Pausinha.Application.Interfaces;

namespace Pausinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BreakSessionsController : ControllerBase
    {
        private readonly IBreakSessionService _service;

        public BreakSessionsController(IBreakSessionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sessions = await _service.GetAllAsync();

            return Ok(sessions.Select(s => new BreakSessionResponseDto
            {
                Id = s.Id,
                EmployeeId = s.EmployeeId,
                BreakType = s.BreakType,
                StartedAt = s.StartedAt,
                EndedAt = s.EndedAt,
                DurationMinutes = s.DurationMinutes
            }));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _service.GetByIdAsync(id);
            if (s == null) return NotFound();

            return Ok(new BreakSessionResponseDto
            {
                Id = s.Id,
                EmployeeId = s.EmployeeId,
                BreakType = s.BreakType,
                StartedAt = s.StartedAt,
                EndedAt = s.EndedAt,
                DurationMinutes = s.DurationMinutes
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BreakSessionCreateDto dto)
        {
            var created = await _service.CreateAsync(dto.EmployeeId, dto.BreakType, dto.StartedAt, dto.EndedAt);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, new BreakSessionResponseDto
            {
                Id = created.Id,
                EmployeeId = created.EmployeeId,
                BreakType = created.BreakType,
                StartedAt = created.StartedAt,
                EndedAt = created.EndedAt,
                DurationMinutes = created.DurationMinutes
            });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] BreakSessionUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto.BreakType, dto.StartedAt, dto.EndedAt);

            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (!success) return NotFound();

            return NoContent();
        }
    }
}
