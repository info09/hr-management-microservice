using AutoMapper;
using Contracts.Domains.Interfaces;
using Employee.API.Entities;
using Employee.API.Persistance;
using Employee.API.Repositories.Interfaces;
using Infrastructures.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Employee;
using Shared.SeedWorks;

namespace Employee.API.Repositories
{
    public class EmployeeRepository : RepositoryBaseAsync<Employees, Guid, EmployeeContext>, IEmployeeRepository
    {
        private readonly IMapper _mapper;
        public EmployeeRepository(EmployeeContext dbContext, IUnitOfWork<EmployeeContext> unitOfWork, IMapper mapper) : base(dbContext, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<ApiResult<EmployeeDto>> CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employees>(employeeDto);
            await CreateAsync(employee);
            //var data = await GetEmployee(id);
            return new ApiResult<EmployeeDto>(true);
        }

        public async Task<ApiResult<bool>> DeleteEmployee(Guid id)
        {
            var employee = await GetByIdAsync(id);
            if (employee != null) Delete(employee);
            await SaveChangesAsync();
            return new ApiResult<bool>(true);
        }

        public async Task<ApiResult<PagedList<EmployeeDto>>> GetAllEmployees(EmployeeSearchDto search)
        {
            var query = FindAll();

            query = !string.IsNullOrEmpty(search.SearchTerm) 
                ? query.Where(i => i.FirstName!.ToLower().Contains(search.SearchTerm.ToLower()) || 
                                           i.LastName!.ToLower().Contains(search.SearchTerm.ToLower())) 
                : query;

            query = search.DepartmentId.HasValue ? query.Where(i => i.DepartmentId == search.DepartmentId.Value) : query;
            query = search.PositionId.HasValue ? query.Where(i => i.PositionId == search.PositionId.Value) : query;

            var total = await query.CountAsync();
            var data = await query.Skip((search.PageIndex - 1) * search.PageSize).Take(search.PageSize).Select(i => i.ToDto()).ToListAsync();
            var result = new PagedList<EmployeeDto>
            {
                Items = data,
                TotalRecords = total,
                PageIndex = search.PageIndex,
                PageSize = search.PageSize,
            };
            return new ApiResult<PagedList<EmployeeDto>>(true, result);
        }

        public async Task<ApiResult<EmployeeDto?>> GetEmployee(Guid id)
        {
            var data = await GetByIdAsync(id);
            var result = data == null ? null : data.ToDto();
            return new ApiResult<EmployeeDto?>(true, result);
        }

        public async Task<ApiResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var data = await FindAll().Select(i => i.ToDto()).ToListAsync();
            return new ApiResult<IEnumerable<EmployeeDto>>(true, data);
        }

        public async Task<ApiResult<EmployeeDto>> UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employees>(employeeDto);
            await UpdateAsync(employee);
            return new ApiResult<EmployeeDto>(true, employee.ToDto());
        }
    }
}
