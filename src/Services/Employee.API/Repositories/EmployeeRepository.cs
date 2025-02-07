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
            var id = await CreateAsync(employee);
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
            if (!string.IsNullOrEmpty(search.SearchTerm))
            {
                query = query.Where(i => i.FirstName!.ToLower().Contains(search.SearchTerm.ToLower()) ||
                                            i.LastName!.ToLower().Contains(search.SearchTerm.ToLower()));
            }
            var total = await query.CountAsync();
            var data = await query.Skip((search.PageIndex - 1) * search.PageSize).Take(search.PageSize).Select(i => i.ToDto()).ToListAsync();
            var result = new PagedList<EmployeeDto>(data, total, search.PageIndex, search.PageSize);
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

        public async Task<ApiResult<EmployeeDto>> UpdateEmployee(Employees product)
        {
            await UpdateAsync(product);
            return new ApiResult<EmployeeDto>(true, product.ToDto());
        }
    }
}
