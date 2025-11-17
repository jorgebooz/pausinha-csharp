using Pausinha.Application.Interfaces;
using Pausinha.Domain.Entities;

namespace Pausinha.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Company>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Company?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task<Company> CreateAsync(string name)
        {
            var company = new Company
            {
                Name = name
            };

            return await _repository.AddAsync(company);
        }

        public async Task<bool> UpdateAsync(int id, string name)
        {
            var company = await _repository.GetByIdAsync(id);
            if (company == null)
                return false;

            company.Name = name;
            await _repository.UpdateAsync(company);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await _repository.GetByIdAsync(id);
            if (company == null)
                return false;

            await _repository.DeleteAsync(company);
            return true;
        }
    }
}
