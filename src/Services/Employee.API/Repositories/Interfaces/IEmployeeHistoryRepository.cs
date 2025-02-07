using Contracts.Domains.Interfaces;
using Employee.API.Entities;
using Employee.API.Persistance;
using Shared.Dtos.Employees.EmployeeHistory;
using Shared.SeedWorks;

namespace Employee.API.Repositories.Interfaces
{
    public interface IEmployeeHistoryRepository : IRepositoryBaseAsync<EmployeeHistories, Guid, EmployeeContext>
    {
        Task<ApiResult<bool>> AddHistory(CreateEmployeeHistoryDto dto);
    }
}
