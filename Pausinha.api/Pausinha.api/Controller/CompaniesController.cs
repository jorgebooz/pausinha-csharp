using Microsoft.AspNetCore.Mvc;
using Pausinha.Api.DTOs;
using Pausinha.Application.Interfaces;

namespace Pausinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompaniesController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _service.GetAllAsync();
            return Ok(companies.Select(c => new CompanyResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                CreatedAt = c.CreatedAt
            }));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _service.GetByIdAsync(id);
            if (company == null) return NotFound();

            return Ok(new CompanyResponseDto
            {
                Id = company.Id,
                Name = company.Name,
                CreatedAt = company.CreatedAt
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyCreateDto dto)
        {
            var newCompany = await _service.CreateAsync(dto.Name);

            return CreatedAtAction(nameof(GetById),
                new { id = newCompany.Id },
                new CompanyResponseDto
                {
                    Id = newCompany.Id,
                    Name = newCompany.Name,
                    CreatedAt = newCompany.CreatedAt
                });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CompanyUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto.Name);

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
