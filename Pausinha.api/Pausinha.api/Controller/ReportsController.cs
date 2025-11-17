using Microsoft.AspNetCore.Mvc;
using Pausinha.Api.DTOs;
using Pausinha.Application.Interfaces;

namespace Pausinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        // GET api/v1/reports/employees/{employeeId}/weekly?referenceDate=2025-11-17
        [HttpGet("employees/{employeeId:int}/weekly")]
        public async Task<IActionResult> GetEmployeeWeeklyReport(
            int employeeId,
            [FromQuery] DateTime? referenceDate)
        {
            var date = referenceDate ?? DateTime.UtcNow;
            var result = await _reportService.GetEmployeeWeeklyReportAsync(employeeId, date);

            if (result == null)
                return NotFound();

            var dto = new EmployeeWeeklyReportDto
            {
                EmployeeId = result.EmployeeId,
                EmployeeName = result.EmployeeName,
                CompanyId = result.CompanyId,
                CompanyName = result.CompanyName,
                TotalBreaks = result.TotalBreaks,
                TotalMinutes = result.TotalMinutes,
                AverageBreakMinutes = result.AverageBreakMinutes,
                PeriodStart = result.PeriodStart,
                PeriodEnd = result.PeriodEnd
            };

            return Ok(dto);
        }

        // GET api/v1/reports/companies/{companyId}/weekly?referenceDate=2025-11-17
        [HttpGet("companies/{companyId:int}/weekly")]
        public async Task<IActionResult> GetCompanyWeeklyReport(
            int companyId,
            [FromQuery] DateTime? referenceDate)
        {
            var date = referenceDate ?? DateTime.UtcNow;
            var result = await _reportService.GetCompanyWeeklyReportAsync(companyId, date);

            if (result == null)
                return NotFound();

            var dto = new CompanyWeeklyReportDto
            {
                CompanyId = result.CompanyId,
                CompanyName = result.CompanyName,
                TotalBreaks = result.TotalBreaks,
                TotalMinutes = result.TotalMinutes,
                EmployeesWithBreaks = result.EmployeesWithBreaks,
                AverageMinutesPerEmployee = result.AverageMinutesPerEmployee,
                PeriodStart = result.PeriodStart,
                PeriodEnd = result.PeriodEnd
            };

            return Ok(dto);
        }
    }
}
