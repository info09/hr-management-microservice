using Contracts.Domains.Interfaces;
using Employee.API.Entities;
using Employee.API.Persistance;

namespace Employee.API.Repositories.Interfaces
{
    public interface IDepartmentRepository : IRepositoryBaseAsync<Departments, Guid, EmployeeContext>
    {
        Task<IEnumerable<Departments>> GetDepartments();
        Task<Departments?> GetDepartment(Guid id);
        Task<Departments?> GetDepartmentByDepartmentName(string departmentName);
        Task CreateDepartment(Departments product);
        Task UpdateDepartment(Departments product);
        Task DeleteDepartment(Guid id);
    }
}
