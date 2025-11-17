using Pausinha.Application.Interfaces;
using Pausinha.Domain.Entities;

namespace Pausinha.Application.Services
{
    public class BreakSessionService : IBreakSessionService
    {
        private readonly IBreakSessionRepository _breakRepo;
        private readonly IEmployeeRepository _employeeRepo;

        public BreakSessionService(IBreakSessionRepository breakRepo, IEmployeeRepository employeeRepo)
        {
            _breakRepo = breakRepo;
            _employeeRepo = employeeRepo;
        }

        public Task<List<BreakSession>> GetAllAsync()
        {
            return _breakRepo.GetAllAsync();
        }

        public Task<BreakSession?> GetByIdAsync(int id)
        {
            return _breakRepo.GetByIdAsync(id);
        }

        public async Task<BreakSession> CreateAsync(int employeeId, string breakType, DateTime start, DateTime end)
        {
            var employee = await _employeeRepo.GetByIdAsync(employeeId);

            if (employee == null)
                throw new Exception("Employee not found");

            var session = new BreakSession
            {
                EmployeeId = employeeId,
                BreakType = breakType,
                StartedAt = start,
                EndedAt = end
            };

            return await _breakRepo.AddAsync(session);
        }

        public async Task<bool> UpdateAsync(int id, string breakType, DateTime start, DateTime end)
        {
            var existing = await _breakRepo.GetByIdAsync(id);
            if (existing == null)
                return false;

            existing.BreakType = breakType;
            existing.StartedAt = start;
            existing.EndedAt = end;

            await _breakRepo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _breakRepo.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _breakRepo.DeleteAsync(existing);
            return true;
        }
    }
}
