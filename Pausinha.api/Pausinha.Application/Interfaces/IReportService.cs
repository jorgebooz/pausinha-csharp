using Pausinha.Application.Models;

namespace Pausinha.Application.Interfaces
{
    public interface IReportService
    {
        Task<EmployeeWeeklyReportResult?> GetEmployeeWeeklyReportAsync(int employeeId, DateTime referenceDate);
        Task<CompanyWeeklyReportResult?> GetCompanyWeeklyReportAsync(int companyId, DateTime referenceDate);
    }
}
