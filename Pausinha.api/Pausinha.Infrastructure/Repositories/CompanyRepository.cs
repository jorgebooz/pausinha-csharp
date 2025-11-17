using Microsoft.EntityFrameworkCore;
using Pausinha.Application.Interfaces;
using Pausinha.Domain.Entities;
using Pausinha.Infrastructure.Persistence;

namespace Pausinha.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly PausinhaDbContext _context;

        public CompanyRepository(PausinhaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _context.Companies.AsNoTracking().ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _context.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Company> AddAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}
