using Contracts.Domains.Interfaces;
using Employee.API.Entities;
using Employee.API.Persistance;
using Employee.API.Repositories.Interfaces;
using Infrastructures.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Employee.API.Repositories
{
    public class DepartmentRepository : RepositoryBaseAsync<Departments, Guid, EmployeeContext>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeContext dbContext, IUnitOfWork<EmployeeContext> unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public Task CreateDepartment(Departments product) => CreateAsync(product);

        public async Task DeleteDepartment(Guid id)
        {
            var product = await GetDepartment(id);
            if (product != null) Delete(product);
            await SaveChangesAsync();
        }

        public Task<Departments?> GetDepartment(Guid id) => GetByIdAsync(id);

        public Task<Departments?> GetDepartmentByDepartmentName(string departmentName) => FindByCondition(x => x.DepartmentName.Equals(departmentName)).SingleOrDefaultAsync();

        public async Task<IEnumerable<Departments>> GetDepartments()
        {
            return await FindAll().ToListAsync();
        }

        public Task UpdateDepartment(Departments product) => UpdateAsync(product);
    }
}
