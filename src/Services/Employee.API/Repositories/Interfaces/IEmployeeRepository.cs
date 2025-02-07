using Contracts.Domains.Interfaces;
using Employee.API.Entities;
using Employee.API.Persistance;
using Shared.Dtos.Employee;
using Shared.SeedWorks;

namespace Employee.API.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepositoryBaseAsync<Employees, Guid, EmployeeContext>
    {
        Task<ApiResult<IEnumerable<EmployeeDto>>> GetEmployees();
        Task<ApiResult<PagedList<EmployeeDto>>> GetAllEmployees(EmployeeSearchDto search);
        Task<ApiResult<EmployeeDto?>> GetEmployee(Guid id);
        Task<ApiResult<EmployeeDto>> CreateEmployee(CreateEmployeeDto employeeDto);
        Task<ApiResult<EmployeeDto>> UpdateEmployee(UpdateEmployeeDto employeeDto);
        Task<ApiResult<bool>> DeleteEmployee(Guid id);
    }
}
