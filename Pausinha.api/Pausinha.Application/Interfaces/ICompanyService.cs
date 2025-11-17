using Pausinha.Domain.Entities;

namespace Pausinha.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(int id);
        Task<Company> CreateAsync(string name);
        Task<bool> UpdateAsync(int id, string name);
        Task<bool> DeleteAsync(int id);
    }
}
