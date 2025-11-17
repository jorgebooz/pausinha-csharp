using Pausinha.Application.Interfaces;
using Pausinha.Domain.Entities;

namespace Pausinha.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ICompanyRepository _companyRepo;

        public EmployeeService(IEmployeeRepository employeeRepo, ICompanyRepository companyRepo)
        {
            _employeeRepo = employeeRepo;
            _companyRepo = companyRepo;
        }

        public Task<List<Employee>> GetAllAsync()
        {
            return _employeeRepo.GetAllAsync();
        }

        public Task<Employee?> GetByIdAsync(int id)
        {
            return _employeeRepo.GetByIdAsync(id);
        }

        public async Task<Employee> CreateAsync(int companyId, string name, string workMode)
        {
            var company = await _companyRepo.GetByIdAsync(companyId);
            if (company == null)
                throw new Exception("Company not found");

            var employee = new Employee
            {
                CompanyId = companyId,
                Name = name,
                WorkMode = workMode
            };

            return await _employeeRepo.AddAsync(employee);
        }

        public async Task<bool> UpdateAsync(int id, string name, string workMode)
        {
            var existing = await _employeeRepo.GetByIdAsync(id);
            if (existing == null)
                return false;

            existing.Name = name;
            existing.WorkMode = workMode;

            await _employeeRepo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _employeeRepo.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _employeeRepo.DeleteAsync(existing);
            return true;
        }
    }
}
