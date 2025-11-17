using Pausinha.Domain.Entities;

namespace Pausinha.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> CreateAsync(int companyId, string name, string workMode);
        Task<bool> UpdateAsync(int id, string name, string workMode);
        Task<bool> DeleteAsync(int id);
    }
}
