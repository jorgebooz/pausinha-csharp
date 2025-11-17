using Microsoft.EntityFrameworkCore;
using Pausinha.Application.Interfaces;
using Pausinha.Domain.Entities;
using Pausinha.Infrastructure.Persistence;

namespace Pausinha.Infrastructure.Repositories
{
    public class BreakSessionRepository : IBreakSessionRepository
    {
        private readonly PausinhaDbContext _context;

        public BreakSessionRepository(PausinhaDbContext context)
        {
            _context = context;
        }

        public async Task<List<BreakSession>> GetAllAsync()
        {
            return await _context.BreakSessions.AsNoTracking().ToListAsync();
        }

        public async Task<BreakSession?> GetByIdAsync(int id)
        {
            return await _context.BreakSessions.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BreakSession> AddAsync(BreakSession session)
        {
            _context.BreakSessions.Add(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task UpdateAsync(BreakSession session)
        {
            _context.BreakSessions.Update(session);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BreakSession session)
        {
            _context.BreakSessions.Remove(session);
            await _context.SaveChangesAsync();
        }

        // 🔽 relatórios

        public async Task<List<BreakSession>> GetByEmployeeAndPeriodAsync(int employeeId, DateTime start, DateTime end)
        {
            return await _context.BreakSessions
                .AsNoTracking()
                .Where(b => b.EmployeeId == employeeId &&
                            b.StartedAt >= start &&
                            b.StartedAt < end)
                .ToListAsync();
        }

        public async Task<List<BreakSession>> GetByCompanyAndPeriodAsync(int companyId, DateTime start, DateTime end)
        {
            return await _context.BreakSessions
                .AsNoTracking()
                .Include(b => b.Employee)
                .Where(b => b.Employee.CompanyId == companyId &&
                            b.StartedAt >= start &&
                            b.StartedAt < end)
                .ToListAsync();
        }
    }
}
