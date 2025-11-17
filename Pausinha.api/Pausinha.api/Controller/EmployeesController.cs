using Microsoft.AspNetCore.Mvc;
using Pausinha.Api.DTOs;
using Pausinha.Application.Interfaces;

namespace Pausinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _service.GetAllAsync();

            return Ok(employees.Select(e => new EmployeeResponseDto
            {
                Id = e.Id,
                CompanyId = e.CompanyId,
                Name = e.Name,
                WorkMode = e.WorkMode,
                CreatedAt = e.CreatedAt
            }));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _service.GetByIdAsync(id);
            if (emp == null) return NotFound();

            return Ok(new EmployeeResponseDto
            {
                Id = emp.Id,
                CompanyId = emp.CompanyId,
                Name = emp.Name,
                WorkMode = emp.WorkMode,
                CreatedAt = emp.CreatedAt
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateDto dto)
        {
            var employee = await _service.CreateAsync(dto.CompanyId, dto.Name, dto.WorkMode);

            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, new EmployeeResponseDto
            {
                Id = employee.Id,
                CompanyId = employee.CompanyId,
                Name = employee.Name,
                WorkMode = employee.WorkMode,
                CreatedAt = employee.CreatedAt
            });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto.Name, dto.WorkMode);

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
