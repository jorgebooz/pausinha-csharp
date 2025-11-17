using Pausinha.Domain.Entities;

namespace Pausinha.Application.Interfaces
{
    public interface IBreakSessionService
    {
        Task<List<BreakSession>> GetAllAsync();
        Task<BreakSession?> GetByIdAsync(int id);
        Task<BreakSession> CreateAsync(int employeeId, string breakType, DateTime start, DateTime end);
        Task<bool> UpdateAsync(int id, string breakType, DateTime start, DateTime end);
        Task<bool> DeleteAsync(int id);
    }
}
