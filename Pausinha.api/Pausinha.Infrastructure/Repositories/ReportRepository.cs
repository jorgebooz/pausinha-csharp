using Pausinha.Application.Interfaces;
using Pausinha.Application.Models;

namespace Pausinha.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ICompanyRepository _companyRepo;
        private readonly IBreakSessionRepository _breakRepo;

        public ReportService(
            IEmployeeRepository employeeRepo,
            ICompanyRepository companyRepo,
            IBreakSessionRepository breakRepo)
        {
            _employeeRepo = employeeRepo;
            _companyRepo = companyRepo;
            _breakRepo = breakRepo;
        }

        public async Task<EmployeeWeeklyReportResult?> GetEmployeeWeeklyReportAsync(int employeeId, DateTime referenceDate)
        {
            var employee = await _employeeRepo.GetByIdAsync(employeeId);
            if (employee == null)
                return null;

            var company = await _companyRepo.GetByIdAsync(employee.CompanyId);
            if (company == null)
                return null;

            // janela de 7 dias: [refDate-6, refDate+1)
            var periodEnd = referenceDate.Date.AddDays(1);
            var periodStart = referenceDate.Date.AddDays(-6);

            var sessions = await _breakRepo.GetByEmployeeAndPeriodAsync(employeeId, periodStart, periodEnd);

            var totalBreaks = sessions.Count;
            var totalMinutes = sessions.Sum(s => s.DurationMinutes);
            var avgMinutes = totalBreaks > 0 ? (double)totalMinutes / totalBreaks : 0;

            return new EmployeeWeeklyReportResult
            {
                EmployeeId = employee.Id,
                EmployeeName = employee.Name,
                CompanyId = company.Id,
                CompanyName = company.Name,
                TotalBreaks = totalBreaks,
                TotalMinutes = totalMinutes,
                AverageBreakMinutes = avgMinutes,
                PeriodStart = periodStart,
                PeriodEnd = periodEnd
            };
        }

        public async Task<CompanyWeeklyReportResult?> GetCompanyWeeklyReportAsync(int companyId, DateTime referenceDate)
        {
            var company = await _companyRepo.GetByIdAsync(companyId);
            if (company == null)
                return null;

            var periodEnd = referenceDate.Date.AddDays(1);
            var periodStart = referenceDate.Date.AddDays(-6);

            var sessions = await _breakRepo.GetByCompanyAndPeriodAsync(companyId, periodStart, periodEnd);

            var totalBreaks = sessions.Count;
            var totalMinutes = sessions.Sum(s => s.DurationMinutes);
            var employeesWithBreaks = sessions.Select(s => s.EmployeeId).Distinct().Count();
            var avgMinutesPerEmployee = employeesWithBreaks > 0 ? (double)totalMinutes / employeesWithBreaks : 0;

            return new CompanyWeeklyReportResult
            {
                CompanyId = company.Id,
                CompanyName = company.Name,
                TotalBreaks = totalBreaks,
                TotalMinutes = totalMinutes,
                EmployeesWithBreaks = employeesWithBreaks,
                AverageMinutesPerEmployee = avgMinutesPerEmployee,
                PeriodStart = periodStart,
                PeriodEnd = periodEnd
            };
        }
    }
}
