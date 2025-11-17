using Pausinha.Domain.Entities;

namespace Pausinha.Application.Interfaces
{
    public interface IBreakSessionRepository
    {
        Task<List<BreakSession>> GetAllAsync();
        Task<BreakSession?> GetByIdAsync(int id);
        Task<BreakSession> AddAsync(BreakSession session);
        Task UpdateAsync(BreakSession session);
        Task DeleteAsync(BreakSession session);
        Task<List<BreakSession>> GetByEmployeeAndPeriodAsync(int employeeId, DateTime start, DateTime end);
        Task<List<BreakSession>> GetByCompanyAndPeriodAsync(int companyId, DateTime start, DateTime end);
    }
}
